using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    public CapsuleCollider characterCollider;
    public GameObject UIPanel;

    private void Awake()
    {
        //characterCollider = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other == characterCollider)
        {
            Animator animator = UIPanel.GetComponent<Animator>();
            animator.SetBool("IsInsideTrigger", true);
        }

        else
        {
            Animator animator = UIPanel.GetComponent<Animator>();
            animator.SetBool("IsInsideTrigger", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == characterCollider)
        {
            Animator animator = UIPanel.GetComponent<Animator>();
            animator.SetBool("IsInsideTrigger", false);
        }
    }

    public void ChangeTarget(CapsuleCollider collider)
    {
        characterCollider = collider;
    }
}
