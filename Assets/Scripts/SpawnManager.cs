using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount <= 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }

    }

    private Vector3 RandomSpawnPoint()
    {
        float randomXPos = Random.Range(-spawnRange, spawnRange);
        float randomZPos = Random.Range(-spawnRange, spawnRange);

        return new Vector3(randomXPos, 0, randomZPos);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPoint(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerUpPrefab, RandomSpawnPoint(), powerUpPrefab.transform.rotation);
    }

}
