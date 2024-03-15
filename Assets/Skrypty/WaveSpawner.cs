using NUnit.Framework;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> livingEnemies;
    [SerializeField] List<Transform> spawnPositions;

    public GameObject NewUpgradeUi;
    public GameObject[] upgradelist;
    public bool canSpawnNextWave;
    public bool ChooseUpgradee;
    public int waveNumber;
    private int upgradeCounter = 0; // Licznik u¿yæ funkcji GenereateUpgrade()

    void Start()
    {

    }

    private void Update()
    {
        if (livingEnemies.Count == 0 && !canSpawnNextWave)
        {
            for (int i = 0; i <= 2; i++)
            {
                GenereateUpgrade();
            }
            NewUpgrade();
        }

        if (livingEnemies.Count == 0 && canSpawnNextWave)
        {
            GenerateWave();
        }
    }

    private void FixedUpdate()
    {
        livingEnemies = livingEnemies.FindAll(item => item != null);
    }

    void GenerateWave()
    {
        foreach (Transform t in spawnPositions)
        {
            int enemyInd = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[enemyInd], t.position, Quaternion.identity);
            livingEnemies.Add(enemy);

        }
        waveNumber += 1;
        canSpawnNextWave = false;
    }


    void NewUpgrade()
    {
        NewUpgradeUi.SetActive(true);
        canSpawnNextWave = false;
    }

    void GenereateUpgrade()
    {
        // Sprawdzanie, czy funkcja GenereateUpgrade() zosta³a ju¿ wywo³ana trzy razy
        if (upgradeCounter < 3)
        {
            int randomnum = Random.Range(0, upgradelist.Length - 1);
            Instantiate(upgradelist[randomnum], NewUpgradeUi.transform);
            Debug.Log("New");
            upgradeCounter++; // Zwiêkszanie licznika po ka¿dym wywo³aniu funkcji
        }
    }

    public void ChooseUpgrade()
    {
        NewUpgradeUi.SetActive(false);
        canSpawnNextWave = true;
    }

}
