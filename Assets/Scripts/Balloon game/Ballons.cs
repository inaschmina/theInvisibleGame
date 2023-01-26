using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 6;
    private float maxSpeed = 12;
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

        // random pos to spawn
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            if (gameManager.isGameActive)
            {
                // create a ray at the touch position
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                // check for a collision at the touch position
                if (Physics.Raycast(ray, out hit))
                {
                    // check if the object hit is the same as the current object
                    if (hit.transform == this.transform)
                    {
                        // destroy the current object
                        Destroy(gameObject);
                        Debug.Log("touched once");
                        gameManager.UpdateScore(pointVal);
                        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
                    }
                }
            }

        }
    }


    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (gameManager.isGameActive) { gameManager.UpdateLives(1); }
        if (gameManager.getLives() == 0) { gameManager.GameOver(); }
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
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
