using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    Vector3 rotation;
    public float speed;
    void Start()
    {
        float randomX = Random.Range(0f, 360f);
        float randomY = Random.Range(0f, 360f);
        float randomZ = Random.Range(0f, 360f);
        rotation = new Vector3(randomX, randomY, randomZ);
    }

    
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime * speed);
    }
}
