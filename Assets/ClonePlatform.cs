using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlatform : MonoBehaviour
{
    public Animator door;

    void Start()
    {
        CloneDestroy.onDestroyClone.AddListener(CheckDestoyStatus);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            door.SetBool("SomeoneInTrigger",true);
        }

        else
        {
            door.SetBool("SomeoneInTrigger", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        door.SetBool("SomeoneInTrigger", false);
    }

    public void CheckDestoyStatus()
    {
        door.SetBool("SomeoneInTrigger", false);
    }
}
