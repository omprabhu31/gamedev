using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    //Private variables
    private float forwardSpeed = 15.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input for movement
        horizontalInput = Input.GetAxis("Player 1 Horizontal");
        forwardInput = Input.GetAxis("Player 1 Vertical");

        // Forward/backward motion depending on input
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * forwardInput);

        // Left or right motion depending on horizontal & forward input (since car should not rotate when at rest)
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
    }
}
