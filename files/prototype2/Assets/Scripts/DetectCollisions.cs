using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Destroy both gameobjects on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent("Collider"))
        {
            Destroy(gameObject.GetComponent("Collider"));
            gameManager.SubtractLives(1);
        }
        else
        {
            //Destroy(other.gameObject);
            other.GetComponent<HungerBar>().FeedAnimal(10);
            // Destroy(other.gameObject);
            // gameManager.AddScore(5);
        }
    }
}
