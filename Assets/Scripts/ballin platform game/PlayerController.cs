using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 20.0f;
    private float turnspeed = 10.0f;
    private GameObject focalPoint;

    // POWER UP
    private bool hasPowerup = false;
    private float powerUpStrength = 15.0f;
    public GameObject powerupIndicator;
  
    private bool gameover = false;
    private bool logged = false;
    public GameObject gameOverScreen;

    private float jumpForce = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            gameover = true;
            if (!logged)
            {
                Debug.Log("Game Over"); // to console log once
            }
            logged = true;
            gameOverScreen.gameObject.SetActive(true);
        }
        else
        {
            // get the device's acceleration in the x and y directions
            float x = Input.acceleration.x *turnspeed;
            float y = Input.acceleration.y *turnspeed;

            // move the player in the corresponding direction
            playerRb.AddForce(new Vector3(x, 0, y) * speed);
        }
    }
    public bool getGameStatus()
    { return gameover; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine()); // create thread and wait 7 seconds
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            int random = Random.Range(0, 1);
            switch(random)
            {
                case 0:
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    }
                    break;
                case 1:
                    Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                    Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); // enemy pos - player pos -> yeets enemy back

                    enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
                    break;
            }
            

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }

    // interface
    // enable timer outside update loop
    
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

}
