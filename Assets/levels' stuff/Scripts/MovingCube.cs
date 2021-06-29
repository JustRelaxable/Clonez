using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x>=30)
        {
            speed = -10;
        }
        else if (gameObject.transform.position.x <= -30)
        {
            speed = 10;
        }
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
}
