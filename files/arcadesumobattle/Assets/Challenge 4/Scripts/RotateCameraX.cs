using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float mouseSensitivity = 200.0f;
    private float rotY;
    private float mouseX;
    public GameObject player;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        mouseX = Input.GetAxis("Mouse X");
        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        Quaternion localRotation = Quaternion.Euler(0f, rotY, 0f);
        transform.rotation = localRotation;
        transform.position = player.transform.position;
    }
}
