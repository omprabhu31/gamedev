using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string prototypeLevel;
    private int score;
    private TMPro.TextMeshPro scoreText;
    private PlayerController playerControllerScript;

    public Transform startingPoint;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshPro>();

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
        UpdateScore();
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(prototypeLevel);
        }
    }

    private void UpdateScore()
    {
        score = (int) playerControllerScript.score;
        scoreText.text = "Score: " + score;
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float distance = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / distance;

        playerControllerScript.playerAnim.speed = 0.5f;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / distance;

            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            yield return null;
        }

        playerControllerScript.playerAnim.speed = 1;
        playerControllerScript.gameOver = false;
    }
}
