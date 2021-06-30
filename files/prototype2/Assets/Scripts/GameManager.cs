using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string gameOverLevel;

    private GameObject scoreText;
    private GameObject lifeText;
    private float score = 0;
    private float lives = 5;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text");
        lifeText = GameObject.Find("Life Text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubtractLives (float value)
    {
        lives -= value;
        Debug.Log("Lives: " + lives);
        lifeText.GetComponent<TextMesh>().text = "Lives: " + lives;

        if (lives == 0)
        {
            SceneManager.LoadScene(gameOverLevel);
        }
    }

    public void AddScore(float value)
    {
        score += value;
        Debug.Log("Score: " + score);
        scoreText.GetComponent<TextMesh>().text = "Score: " + score;
    }
}
