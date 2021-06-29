using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aCTİVATOR : MonoBehaviour
{
    public RoundingRock rock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        rock.gameObject.SetActive(true);
    }
}
