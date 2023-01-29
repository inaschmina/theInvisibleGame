using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); // find player in hierarchy
    }

    // Update is called once per frame
    void Update()
    {
        // normalized - wont get increased force if player further away
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
       
        if(this.CompareTag("FastEnemy"))
        { speed = speed * 2; }
        else if (this.CompareTag("BigBill"))
        { speed = 1; }
 
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
