using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    // Variables
    public GameObject plane;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Set the camera offset
        cameraOffset = transform.position - plane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the camera follow the plane
        transform.position = plane.transform.position + cameraOffset;
    }
}
