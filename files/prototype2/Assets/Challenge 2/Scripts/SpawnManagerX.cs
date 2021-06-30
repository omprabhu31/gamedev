using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -25;
    private float spawnLimitXRight = 10;
    private float spawnPosY = 30;

    private float startDelay = 2.0f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Randomize spawn interval
        spawnInterval = Random.Range(3, 6);

        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0,ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        Invoke("SpawnRandomBall", spawnInterval);
    }

}
