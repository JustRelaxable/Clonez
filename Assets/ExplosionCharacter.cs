using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCharacter : MonoBehaviour
{
    public bool isInsdeSite = false;
    bool isExploded = false;

    public delegate void OnExplosinon();
    public static event OnExplosinon OnExplosion;

    public float lifeTime = 10f;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0 && !isExploded)
        {
            ExplosionCheck();
            isExploded = true;
        }
    }

    public void ExplosionCheck()
    {
        if (isInsdeSite)
        {
            OnExplosion();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ExplosionSite") && other.gameObject.layer == LayerMask.NameToLayer("ExplosionTrigger"))
        {
            isInsdeSite = true;
        }

        else
        {
            isInsdeSite = false;
        }
    }

}
