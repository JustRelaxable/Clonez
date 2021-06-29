using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheclExplosion : MonoBehaviour
{

    public bool IsInsideSite = false;
    
    void Start()
    {
        ExplosionCharacter.OnExplosion += PatlamaDeneme;    
    }

    
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            IsInsideSite = true;
        }
        else
        {
            IsInsideSite = false;
        }
    }

    public void PatlamaDeneme()
    {
        if (IsInsideSite)
        {
            Debug.Log("Patladı Moruq " + gameObject.name); 
        }     
    }
}
