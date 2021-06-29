using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundingRock : MonoBehaviour
{
    public float xSpeed = 5;
    Rigidbody rigidbodyRock;

    private void Awake()
    {
        rigidbodyRock = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        rigidbodyRock.velocity = new Vector3(xSpeed, 0, 0);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            collision.gameObject.transform.position = MainGame.lastCheckPointPos;
            Destroy(gameObject);
        }
    }
}
