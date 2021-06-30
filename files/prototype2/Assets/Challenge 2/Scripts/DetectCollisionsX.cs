using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private GameObject scoreText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreText = GameObject.Find("Score Text");
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameManager.AddScore(10);
    }
}
