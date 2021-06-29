using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    public GameObject spawnObject;
    public BoxCollider boxCollider;
    public float forceToApply;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Start()
    {
        InvokeRepeating("SpawnObject", 0, 3); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        float randomX = Random.Range(transform.position.x - boxCollider.size.x / 2, transform.position.x + boxCollider.size.x / 2);
        Vector3 spawnLoc = new Vector3(randomX, transform.position.y, transform.position.z);


        int scale = Random.Range(1, 5);

        spawnObject.transform.localScale = new Vector3(scale,scale,scale);

        GameObject spawnedObject = Instantiate(spawnObject,spawnLoc,Quaternion.identity);

        spawnedObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, forceToApply);
    }
}
