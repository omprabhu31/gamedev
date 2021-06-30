using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -7.5f;
    private float xBound = 30.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy game object out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            //Debug.Log("Game Over!");
            Destroy(gameObject);
            gameManager.SubtractLives(1);
        }
        else if (transform.position.x < -xBound)
        {
            //Debug.Log("Game Over :(");
            Destroy(gameObject);
            gameManager.SubtractLives(1);
        }
        else if (transform.position.x > xBound)
        {
            //Debug.Log("Game Over :(");
            Destroy(gameObject);
            gameManager.SubtractLives(1 );
        }
    }
}
