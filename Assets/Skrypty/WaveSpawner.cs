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
    public Slider levelSlider;
    public List<GameObject> enemyPrefabs;
    public List<GameObject> livingEnemies;
    [SerializeField] List<Transform> spawnPositions;
    int enemySpawnPos = 0;

    public GameObject NewUpgradeUi;
    public GameObject[] upgradelist;
    public bool canSpawnNextWave;
    public bool choosingUpgrade;

    int enemiesAtOnce = 3;
    int playerLevel = 1;
    public int kills = 0;
    public int killsToNewLevel = 3;

    private void Update()
    {
        if (choosingUpgrade) return;
        levelSlider.value = kills;

        if (livingEnemies.Count <= enemiesAtOnce/2)
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
                upgradeElement.GetComponent<Button>().onClick.AddListener(() => ChooseUpgrade(upgradeElement.transform.Find("name").GetComponent<Text>().text));
            }
            NewUpgrade();
            killsToNewLevel *= 2;
            levelSlider.maxValue = killsToNewLevel;
            enemiesAtOnce += 1;
            kills = 0;
        }
    }

    private void FixedUpdate()
    {
        livingEnemies = livingEnemies.FindAll(item => item != null);
    }

    void GenerateEnemies()
    {
        while(livingEnemies.Count < enemiesAtOnce)
        {
            int enemyInd = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[enemyInd], spawnPositions[enemySpawnPos].position, Quaternion.identity);
            livingEnemies.Add(enemy);
            enemySpawnPos++;
            if (enemySpawnPos == spawnPositions.Count) enemySpawnPos = 0;
        }
    }

    void NewUpgrade()
    {
        NewUpgradeUi.SetActive(true);
        //canSpawnNextWave = false;
    }

    public void ChooseUpgrade(string name)
    {
        NewUpgradeUi.SetActive(false);
        choosingUpgrade = false;
        Time.timeScale = 1;
        //canSpawnNextWave = true;
    }

}
