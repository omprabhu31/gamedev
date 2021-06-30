using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakePlayerToManu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string menuLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(menuLevel);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            pauseMenu.SetActive(false);
        }
    }
}
