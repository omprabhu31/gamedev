using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLose : MonoBehaviour
{
    public string prototypeLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPrototype()
    {
        SceneManager.LoadScene(prototypeLevel);
    }
}
