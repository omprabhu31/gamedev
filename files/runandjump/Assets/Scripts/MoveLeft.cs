using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 25.0f;
    private PlayerController playerControllerScript;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        // Get player script component
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move background & obstacles left as long as the game is not over
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Destroy obstacle when it moves too far left
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        // Player dash ability
        if (Input.GetKey(KeyCode.LeftShift) && !playerControllerScript.gameOver && playerControllerScript.jumps == 2)
        {
            speed = 50;
            playerControllerScript.playerAnim.speed = 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 25;
            playerControllerScript.playerAnim.speed = 1;
        }
    }
}
