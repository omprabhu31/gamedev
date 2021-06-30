using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float dogSpawnInterval = 0.75f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = dogSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure player cannot spam dogs
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // On spacebar/LMB press, send dog
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = dogSpawnInterval;
            }
        }
    }
}
