using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerCar : MonoBehaviour
{
    // TITLE
    public GameObject titleScreen;

    // GAME OVER TEXT
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    // time
    private float startTime;
    private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        titleScreen.gameObject.SetActive(false);

        startTime = Time.time;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
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

    // Update is called once per frame
    void Update()
    {
        if(Time.time == 60)
        {
            GameOver();
        }
    }
}
