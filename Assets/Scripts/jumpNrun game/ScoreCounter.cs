using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    private float timer = 0;
    private float breakTime = 1;

    private PlayerController2 playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerControllerScript.gameOver)
        {
            timer += Time.deltaTime; // counter to prevent from console spamming
            if (timer >= breakTime)
            {
                if (!playerControllerScript.gameOver)
                { score += 1; }
                Debug.Log("Score: " + score);
                timer = 0; 
            }

            if(score%12 == 0)
            { playerControllerScript.getFirework().Play(); }
        }
        
    }
}
