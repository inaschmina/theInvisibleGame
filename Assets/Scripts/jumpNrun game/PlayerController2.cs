using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlayerController2 : MonoBehaviour
{
    private ARSessionOrigin m_ARSessionOrigin;
    private Rigidbody playerRb;
    private float jumpForce = 600;
    private float gravityModifier = 1.9f;
    private bool isOnGround = true;
    public bool gameOver = false;

    // Movement extras
    private bool doubleJump = false;
    private float boostForce = 100;
    public bool boost = false;

    // Particles
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworkParticle;

    // Animation
    private Animator playerAnim;

    // Audio
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        m_ARSessionOrigin = GetComponent<ARSessionOrigin>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && isOnGround && !gameOver)
            {
                jump();
            }
            else if (touch.phase == TouchPhase.Began && !isOnGround && !gameOver)
            {
                if (!doubleJump)
                {
                    jump();
                    doubleJump = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
            if (!gameOver)
            { dirtParticle.Play(); }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
        }
    }

    private void jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    public Animator getAnim()
    { return playerAnim; }

    public ParticleSystem getFirework()
    { return fireworkParticle; }

}