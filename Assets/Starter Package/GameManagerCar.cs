using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerCar : MonoBehaviour
{
    // GAME OVER TEXT
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button quitButton;

    // time
    public float startTime;
    public TextMeshProUGUI timeText;

    private bool GameStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        GameStatus = true;
        startTime = Time.time;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        GameStatus = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("World");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameStatus)
        {
            float elapsedTime = Time.time - startTime;
            timeText.text = "Elapsed Time: " + elapsedTime.ToString("0.0");
            if(elapsedTime > 60)
            { GameOver();  }
        }
    }
}
