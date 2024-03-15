using NUnit.Framework;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public List<GameObject> livingEnemies;
    [SerializeField] List<Transform> spawnPositions;
    void Start()
    {
        
    }

    private void Update()
    {
        if (livingEnemies.Count == 0) {
            GenerateWave();
        }
    }

    private void FixedUpdate()
    {
        livingEnemies = livingEnemies.FindAll(item => item != null);
    }

    void GenerateWave()
    {
        foreach(Transform t in spawnPositions)
        {
            int enemyInd = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[enemyInd], t.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().Setup();
            livingEnemies.Add(enemy);
        }
    }
}
