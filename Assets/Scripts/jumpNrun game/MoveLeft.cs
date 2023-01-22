using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController2 playerControllerScript; // reference to playercontroller script
    private SpawnManager2 spawnManagerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>(); // to find in hierarchy and get component
        spawnManagerScript = GameObject.Find("SpawnManager2").GetComponent<SpawnManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver) // will stop moving if game over
        {
            if(playerControllerScript.boost)
            { 
                speed = 50;
                playerControllerScript.getAnim().SetFloat("Speed_f", 2);
            }
            else
            { 
                speed = 30;
                playerControllerScript.getAnim().SetFloat("Speed_f", 1);
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
