using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Taş"))
        {
            Destroy(other.gameObject);
        }
        other.gameObject.transform.position = MainGame.lastCheckPointPos;


    }
}
