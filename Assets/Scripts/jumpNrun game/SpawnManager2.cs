using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour
{
    //public GameObject obstaclePrefab;
    public GameObject[] obstaclePrefabs;
    //private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float repeatRate = 2;
    private float startDelay = 2;
    private PlayerController2 playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SpawnObstacle()
    {
        // Set random spawn location and random object index
        int stacks = Random.Range(0, 3);
        int index = Random.Range(0, obstaclePrefabs.Length);
        Vector3 firstSpawnPos = new Vector3(Random.Range(30, 35), 0, 0);
        Vector3 secondSpawnPos = new Vector3(Random.Range(33, 36), 0, 0);

        if (!playerControllerScript.gameOver)
        {
            switch(stacks)
            {
                case 1:
                    Instantiate(obstaclePrefabs[index], firstSpawnPos, obstaclePrefabs[index].transform.rotation);
                    break;
                case 2:
                    Instantiate(obstaclePrefabs[index], firstSpawnPos, obstaclePrefabs[index].transform.rotation);
                    if (index == 0)
                    { Instantiate(obstaclePrefabs[index], firstSpawnPos, obstaclePrefabs[index].transform.rotation); }
                    else
                    { Instantiate(obstaclePrefabs[index], secondSpawnPos, obstaclePrefabs[index].transform.rotation); }
                    break;
            }
        }
    }
}
