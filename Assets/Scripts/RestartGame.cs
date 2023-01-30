using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartingGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartingGame()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
