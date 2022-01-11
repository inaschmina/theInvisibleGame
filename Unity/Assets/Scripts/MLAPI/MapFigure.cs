using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapFigure : MonoBehaviour
{

    public Vector3 currentTarget;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime * speed);
        }
    }
}
