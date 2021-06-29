using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Transform currentTarget;

    Rigidbody obstacleRigidbody;
    public float maximumDistance;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //currentTarget = endPoint;
    }

    
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector3.Lerp(transform.position, currentTarget.position, Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.SetParent(this.transform);
        collision.gameObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
        collision.gameObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
    }
}
