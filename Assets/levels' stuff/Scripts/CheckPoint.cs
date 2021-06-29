using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   public Vector3 restartPoint;
    GameObject clone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="clone")
        {
              clone = other.gameObject;
              Debug.Log("it is working");
        }
       
    }

    private void Update()
    {
        if (clone==null)
        {
            return;
        }
        else if (clone.GetComponent<ThirdPersonUserControl>().isActive)
        {
            Debug.Log("it is perfectly working");
            restartPoint = gameObject.transform.position;
        }
    }
}
