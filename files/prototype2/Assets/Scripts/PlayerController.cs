using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float playerSpeed = 25.0f;

    private float xRange = 16.5f;
    private float zLowerLimit = -1.5f;
    private float zUpperLimit = 5.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move the player left or right based on input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);

        // Keep the player inbounds
        if (transform.position.x < -xRange) // Left bound
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) // Right bound
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zLowerLimit) // Lower bound
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerLimit);
        }
        if (transform.position.z > zUpperLimit) // Top bound
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperLimit) ;
        }

        // Check for spacebar press
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            //Debug.Log("Spacebar/Mouse0 Key Down");
        }
    }
}
