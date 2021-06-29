using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void DisableObject()
    {
        this.gameObject.SetActive(false);
        Invoke("EnableObject", 2);
    }
    
    public void EnableObject()
    {
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            Invoke("DisableObject", 2);
        }
    }
}
