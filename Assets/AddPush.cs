using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPush : MonoBehaviour
{
    Rigidbody rb;
    public float yForce = 0.2f;
    public float directionalForce = 50f;
    private void Awake()
    {
        //rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("clone"))
        {
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = collision.gameObject.transform.position - collision.GetContact(0).point;
            Vector3 dirToApply = new Vector3(dir.x, yForce, dir.z);
            StartCoroutine(DisablePlayerControllerAndCollider(collision.gameObject.GetComponent<ThirdPersonCharacter>()));
            playerRB.AddForce(directionalForce*dirToApply,ForceMode.VelocityChange);
            
        }
    }

    IEnumerator DisablePlayerControllerAndCollider(ThirdPersonCharacter character)
    {
        character.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        //character.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        character.enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
        //character.gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
