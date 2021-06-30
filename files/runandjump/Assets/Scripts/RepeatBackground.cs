using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // Get half the background image width
        xOffset = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - xOffset)
        {
            // Reset position after background travels half its width
            transform.position = startPos;
        }
    }
}
