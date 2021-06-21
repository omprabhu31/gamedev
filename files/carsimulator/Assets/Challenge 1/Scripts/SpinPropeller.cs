using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    // Variables
    private float rotationSpeed = 2160.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make the propeller rotate at a constant rate
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
