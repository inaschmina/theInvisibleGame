using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawnManager : MonoBehaviour
{
    public GameObject targets;
    private float spawnRate = 1.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            StartGame(gameManager.getDifficulty());
        }
    }

    public void StartGame(float difficulty)
    {
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
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

        while (gameManager.isGameActive)
        {
            //int index = Random.Range(0, targets.Count);
            Instantiate(targets, mainCameraPosition + mainCameraForward * 100f, Quaternion.identity);
            Debug.Log(targets.transform.position.ToString());
            Debug.Log(targets.transform.forward.ToString());
            yield return new WaitForSeconds(spawnRate);
        }

    }

}
