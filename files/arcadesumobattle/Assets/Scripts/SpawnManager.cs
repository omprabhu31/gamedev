using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject bossPrefab;

    private float spawnRangeX = 9.0f;
    private float spawnRangeZ = 9.0f;
    private float spawnPosY = 0.2f;

    private int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IncreaseEnemyCount();
    }

    private void IncreaseEnemyCount()
    {
        int enemy1Count = FindObjectsOfType<Enemy>().Length;
        int enemy2Count = FindObjectsOfType<Enemy2>().Length;
        enemyCount = enemy1Count + enemy2Count;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveNumber);
            waveNumber++;
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (enemiesToSpawn <= 1)
            {
                Instantiate(enemyPrefabs[0], GetRandomPosition(), enemyPrefabs[0].transform.rotation);
            }
            else if (enemiesToSpawn % 3 == 0)
            {
                for (int j = 0; j < (enemiesToSpawn/3); j++)
                {
                    Instantiate(bossPrefab, GetRandomPosition(), bossPrefab.transform.rotation);
                    int randomIndex = Random.Range(0, enemyPrefabs.Length);
                    Instantiate(enemyPrefabs[randomIndex], GetRandomPosition(), enemyPrefabs[randomIndex].transform.rotation);
                }
                SpawnPowerups();
                return;
            }
            else
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomIndex], GetRandomPosition(), enemyPrefabs[randomIndex].transform.rotation);
            }
        }
        SpawnPowerups();
    }

    private void SpawnPowerups()
    {
        int powerupsToSpawn = (waveNumber - 1) / 3;
        for (int i = 0; i <= powerupsToSpawn; i++)
        {
            int randomIndex = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomIndex], GetRandomPosition(), powerupPrefabs[randomIndex].transform.rotation);
        }
    }

    public Vector3 GetRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosX);

        return randomPos;
    }
}
