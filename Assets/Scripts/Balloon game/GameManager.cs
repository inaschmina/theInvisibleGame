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
    public GameObject targets;
    private float spawnRate = 1.0f;
    public bool isGameActive;

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
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(0);
        spawnRate /= difficulty;

        titleScreen.gameObject.SetActive(false);
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

    public void QuitGame()
    {
        SceneManager.LoadScene("World");
    }

    IEnumerator SpawnTarget()
    {


        // Get the position of the AR camera
        GameObject mainCamera = Camera.main.gameObject;

        // Get the Transform component of the main camera GameObject
        Transform mainCameraTransform = mainCamera.transform;

        // Get the position and forward direction of the main camera
        Vector3 mainCameraPosition = mainCameraTransform.position;
        Vector3 mainCameraForward = mainCameraTransform.forward;
        // Instantiate the game object at the spawn position

        while (isGameActive)
        {
            //int index = Random.Range(0, targets.Count);
            Instantiate(targets, mainCameraPosition + mainCameraForward * 100f, Quaternion.identity);
            Debug.Log(targets.transform.position.ToString());
            Debug.Log(targets.transform.forward.ToString());    
            yield return new WaitForSeconds(spawnRate);
        }

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