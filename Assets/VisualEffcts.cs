using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffcts : MonoBehaviour
{
    [SerializeField] ParticleSystem cloneSmoke;
    void Start()
    {
        Instantiate(cloneSmoke, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
