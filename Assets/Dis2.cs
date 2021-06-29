using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis2 : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Collider boxCollider;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            StartCoroutine(ActivateObject());
            meshRenderer.enabled = false;
            boxCollider.enabled = false;          
        }
    }

    IEnumerator ActivateObject()
    {
        yield return new WaitForSeconds(2f);
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }

}
