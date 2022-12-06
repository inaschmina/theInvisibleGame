using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 13;
    private float maxSpeed = 17;
    private float maxTorque = 10;
    private float xRange = 4;
    private float xSpawnPos = 6;
    public int pointVal;

    private GameManager gameManager;
    private Break_Ghost break_ghost;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworkParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // add rotation

        // random pos to spawn
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointVal);
            if (gameObject.CompareTag("Mystery"))
            {
                RandomMystery();
            }
            else { Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                break_ghost.break_Ghost();
            }
        }
    } // if clicked 

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive) { gameManager.UpdateLives(1); }
        if (!gameObject.CompareTag("Bad") && gameManager.getLives() == 0) { gameManager.GameOver(); }
    } // if targets pass sensor

    Vector3 RandomForce()
    { return Vector3.up * Random.Range(minSpeed, maxSpeed); }
    float RandomTorque()
    { return Random.Range(-maxTorque, maxTorque); }
    Vector3 RandomSpawnPos()
    { return new Vector3(Random.Range(-xRange, xRange), -xSpawnPos); }

    void RandomMystery()
    {
        if (Random.Range(1, 5) == 2)
        {
            gameManager.UpdateLives(-1); // add extra lives
            Instantiate(fireworkParticle, transform.position, fireworkParticle.transform.rotation);
        }
        else { Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); }
    }
}
