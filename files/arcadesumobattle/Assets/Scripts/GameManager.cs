using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;
    private TMPro.TextMeshPro waveText;
    private GameObject player;
    public string gameOverLevel;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        waveText = GameObject.Find("Wave Number").GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaveText();
        GameOver();
    }

    private void UpdateWaveText()
    {
        if ((spawnManager.waveNumber - 1) % 3 == 0)
        {
            waveText.text = "Enemy Wave " + (spawnManager.waveNumber - 1) + "\n(Boss)";
        }
        else
        {
            waveText.text = "Enemy Wave " + (spawnManager.waveNumber - 1);
        }
    }

    private void GameOver()
    {
        if (player.transform.position.y < -5)
        {
            SceneManager.LoadScene(gameOverLevel);
        }
    }
}
