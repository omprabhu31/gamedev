using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject vehicle;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate offset between camera and vehicle
        cameraOffset = transform.position - vehicle.transform.position;
    }

    // LateUpdate is called after Update, which runs once per frame
    void LateUpdate()
    {
        // Follow the vehicle and offset the camera to get a good view
        transform.position = vehicle.transform.position + cameraOffset;
    }
}
