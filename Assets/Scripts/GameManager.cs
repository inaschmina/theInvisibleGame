using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{

    // GAME SETTINGS
    public bool isGameActive;
    private float difficulty;

    // ----- UI -----

    // TITLE
    public GameObject titleScreen;

    // IN GAME TEXT
    private int lives = 3;
    public TextMeshProUGUI livesText;
    private int score;
    public TextMeshProUGUI scoreText;
    public bool gamePaused;
    public TextMeshProUGUI pausedText;

    // GAME OVER TEXT
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gamePaused = !gamePaused;
            Pause();
        }
    }

    public void StartGame(float difficulty)
    {
        isGameActive = true;
        UpdateScore(0);
        UpdateLives(0);
        this.difficulty = difficulty;
        titleScreen.gameObject.SetActive(false);
    }

    public float getDifficulty()
    {
        return this.difficulty;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0)
        {
            score = 0;
            GameOver();
        }
        scoreText.text = "Score: " + score;
    }

    void Pause()
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
            pausedText.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausedText.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void UpdateLives(int livesLost)
    {
        if (lives > 0)
        {
            lives -= livesLost;
        }
        else
        { GameOver(); }

        livesText.text = "Lives: " + lives;
    }

    public int getLives()
    { return lives; }
}