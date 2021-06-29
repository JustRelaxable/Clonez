using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBoxes : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            GetComponentInParent<Animator>().SetBool("IsPlayerInside", true);
        }

        else
        {
            GetComponentInParent<Animator>().SetBool("IsPlayerInside", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Animator>().SetBool("IsPlayerInside", false);
    }
}
