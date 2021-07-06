using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 0.5f;

    public GameObject gameCanvas;
    public GameObject pauseCanvas;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject otherText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public Slider volumeSlider;
    public AudioSource backgroundMusic;

    private int score;
    private int lives;
    public bool isGameActive;
    public bool isGamePaused;
    public bool isHard = false;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        PauseToggle();
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive & !isGamePaused)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        if (isGameActive)
        {
            lives += livesToAdd;
            lifeText.text = "Lives: " + lives;
            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    public void StartGame(int difficulty)
    {
        otherText.SetActive(true);
        isGameActive = true;
        isGamePaused = false;
        spawnRate /= difficulty;
        IsHard(difficulty);

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);

        titleScreen.SetActive(false);
    }

    public void IsHard(int difficulty)
    {
        if (difficulty == 3)
        {
            isHard = true;
        }
        else
        {
            isHard = false;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseToggle()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isGameActive)
        {
            if (isGamePaused)
            {
                PauseScreenInactive();
            }
            else
            {
                PauseScreenActive();
            }
        }
    }

    public void PauseScreenActive()
    {
        gameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void PauseScreenInactive()
    {
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void MusicVolume()
    {
        backgroundMusic.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("musicVolume", backgroundMusic.volume);
    }
}
