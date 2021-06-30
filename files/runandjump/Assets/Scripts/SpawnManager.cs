using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float startDelay = 4.0f;
    private float repeatRate = 3.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get player script component
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle ()
    {
        if (playerControllerScript.gameOver == false)
        {
            // Random obstacle index
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            spawnPos = new Vector3(25, obstaclePrefabs[obstacleIndex].transform.position.y, obstaclePrefabs[obstacleIndex].transform.position.z);

            // Keep on spawning obstacles provided the game is not over
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
