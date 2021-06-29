using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnColliding : MonoBehaviour
{
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = dir.normalized;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,1000,0));
            Vector3 dirToApply = dir * 1000;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dirToApply.x,0,dirToApply.z,ForceMode.Impulse);
        }
    }
}
