using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHomingWave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyWave", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyWave()
    {
        Destroy(gameObject);
    }
}
