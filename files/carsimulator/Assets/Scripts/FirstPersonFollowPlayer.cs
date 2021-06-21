using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonFollowPlayer : MonoBehaviour
{
    public GameObject vehicle;
    private Vector3 cameraOffset = new Vector3(0, 2, 0.34339f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called after Update, which runs once per frame
    void LateUpdate()
    {
        // Follow the vehicle and offset the camera to get a good view
        transform.position = vehicle.transform.position + cameraOffset;
    }
}
