using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject startButton;
    public GameObject menuButton;
    public GameObject highScore;
    public Text currentScore;
    private int score = 0;
    public bool gameOver = false;
    private int[] highScores = new int[5];
    public Text[] highScoreTexts = new Text[5];

    private void Awake()
    {
        Application.targetFrameRate = 60;
        PauseGame();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartGame();
    }

    public void StartGame()
    {
        gameOverText.SetActive(false);
        startButton.SetActive(false);
        menuButton.SetActive(false);
        highScore.SetActive(false);
        score = 0;
        player.enabled = true;
        scoreText.text = score.ToString();
        Time.timeScale = 1;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverText.SetActive(true);
        startButton.SetActive(true);
        menuButton.SetActive(true);
        SaveHighScores();
        highScore.SetActive(true);
        currentScore.text = score.ToString();
        PauseGame();
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void SaveHighScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if (score > highScores[i])
            {
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                    highScoreTexts[j].text = highScores[j].ToString();
                }
                highScores[i] = score;
                highScoreTexts[i].text = highScores[i].ToString();
                break;
            }
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
