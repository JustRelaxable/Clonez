using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerBox : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            animator.SetBool("IsInsideElevator", true);
        }

        else
        {
            animator.SetBool("IsInsideElevator", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            animator.SetBool("IsInsideElevator", false);
        }
    }
}
