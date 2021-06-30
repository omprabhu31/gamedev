using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startTime = 2.0f;
    private float spawnInterval;
    
    private float spawnRangeX = 16.5f;
    private float spawnPosZ = 20.0f;

    private float sideSpawnX = 20.0f;
    private float sideSpawnZLower = -1.5f;
    private float sideSpawnZUpper = 15.0f;
    private int spawnSide;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomAnimal", startTime);
        Invoke("SpawnFromSide", startTime);
    }

    // Spawns random animal at random position
    void SpawnRandomAnimal()
    {
        // Randomize spawn interval
        spawnInterval = Random.Range(2, 4);

        // Generate random animal index and random spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Instantiate animal at random spawn location
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        Invoke("SpawnRandomAnimal", spawnInterval);
    }

    void SpawnFromSide()
    {
        // Randomize spawn interval
        spawnInterval = Random.Range(2, 4);

        // Generate random animal index
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        // Randomly decide whether to spawn from left or right
        spawnSide = Random.Range(0, 2);
        if (spawnSide == 0)
        {
            Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnZLower, sideSpawnZUpper));
            Vector3 rotation = new Vector3(0, 90, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        }
        else
        {
            Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnZLower, sideSpawnZUpper));
            Vector3 rotation = new Vector3(0, -90, 0);
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
        }

        Invoke("SpawnFromSide", spawnInterval);
    }
}
