using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private float spawnRange = 9;

    // ENEMY
    public int enemyCount;
    private int waveNum = 1;

    // POWER UP
    public GameObject powerupPrefab;

    private PlayerController PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNum);
        SpawnPowerup();

        PlayerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerScript.getGameStatus())
        {
            enemyCount = FindObjectsOfType<Enemy>().Length; // array length returned

            if (enemyCount.Equals(0))
            {
                SpawnEnemyWave(++waveNum);
                SpawnPowerup();
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float SpawnPosX = 0;
        float SpawnPosZ = 0;
        do
        {
            SpawnPosX = Random.Range(-spawnRange, spawnRange);
            SpawnPosZ = Random.Range(-spawnRange, spawnRange);

        } while ((SpawnPosX == 0 && SpawnPosZ == 0));
        

        return  new Vector3(SpawnPosX, 0, SpawnPosZ);
    }

    private void SpawnEnemyWave(int enemies)
    {
        for(int i = 0; i < enemies; i++)
        {
            int random = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[random], GenerateSpawnPosition(), enemyPrefab[random].transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    public int getWaveNum()
    { return waveNum; }
}
