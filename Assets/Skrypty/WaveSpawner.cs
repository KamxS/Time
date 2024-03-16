using NUnit.Framework;
using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> livingEnemies;
    [SerializeField] List<Transform> spawnPositions;

    public GameObject NewUpgradeUi;
    public GameObject[] upgradelist;
    public bool canSpawnNextWave;
    public bool ChooseUpgradee;
    private int upgradeCounter = 0; // Licznik u�y� funkcji GenereateUpgrade()
    public bool choosingUpgrade;

    int enemiesAtOnce = 3;
    int playerLevel = 1;
    public int kills = 0;
    public int killsToNewLevel = 1;

    private void Update()
    {
        if (choosingUpgrade) return;

        if (livingEnemies.Count <= enemiesAtOnce)
        {
            GenerateEnemies();
        }

        if (kills >= killsToNewLevel)
        {
            Time.timeScale = 0;
            choosingUpgrade = true;
            for (int i = 0; i <= 2; i++)
            {
                int randomnum = Random.Range(0, upgradelist.Length - 1);
                GameObject upgradeElement = Instantiate(upgradelist[randomnum], NewUpgradeUi.transform);
                upgradeElement.GetComponent<Button>().onClick.AddListener(ChooseUpgrade);
            //upgradeCounter++; // Zwi�kszanie licznika po ka�dym wywo�aniu funkcji
                //GenereateUpgrade();
            }
            NewUpgrade();
            killsToNewLevel *= 2;
            kills = 0;
        }

        /*
        if (livingEnemies.Count == 0 && canSpawnNextWave)
        {
            GenerateWave();
        }
        */
    }

    private void FixedUpdate()
    {
        livingEnemies = livingEnemies.FindAll(item => item != null);
    }

    /*
    void GenerateWave()
    {
        GenerateEnemies();
        canSpawnNextWave = false;
    }
    */

    void GenerateEnemies()
    {
        foreach (Transform t in spawnPositions)
        {
            if (livingEnemies.Count > enemiesAtOnce) break;
            int enemyInd = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[enemyInd], t.position, Quaternion.identity);
            livingEnemies.Add(enemy);
        }
    }

    void NewUpgrade()
    {
        NewUpgradeUi.SetActive(true);
        //canSpawnNextWave = false;
    }

    void GenereateUpgrade()
    {
        // Sprawdzanie, czy funkcja GenereateUpgrade() zosta�a ju� wywo�ana trzy razy
        if (upgradeCounter < 3)
        {
            int randomnum = Random.Range(0, upgradelist.Length - 1);
            Instantiate(upgradelist[randomnum], NewUpgradeUi.transform);
            upgradeCounter++; // Zwi�kszanie licznika po ka�dym wywo�aniu funkcji
        }
    }

    public void ChooseUpgrade()
    {
        Debug.Log("XD");
        NewUpgradeUi.SetActive(false);
        choosingUpgrade = false;
        Time.timeScale = 1;
        //canSpawnNextWave = true;
    }

}
