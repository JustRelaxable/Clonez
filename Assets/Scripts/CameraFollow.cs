using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraClampX = 60.0f;
    public float mouseSensitivity = 150.0f;
    public float cameraFollowSpeed = 60.0f;
    public GameObject cameraTarget; //   public GameObject cameraTarget;
    float mouseX;
    float mouseY;

    float rotY;
    float rotX;

    public void AttachCameraTargetToCameraBase() //eklendi
    {
        Debug.Log("geldi");
        
    }
    void Start()
    {
        //cameraTarget= GameObject.FindGameObjectWithTag("camrafollow");// eklendi
        AttachCameraTargetToCameraBase();//eklendi
        Vector3 rot = transform.localEulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -cameraClampX, cameraClampX);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    private void CameraUpdater()
    {
        //Transform target = cameraTarget.transform;
        Transform target = GameObject.FindGameObjectWithTag("camrafollow").transform;
        foreach (var item in GameObject.FindGameObjectsWithTag("camrafollow"))
        {
            if (item.GetComponentInParent<ThirdPersonUserControl>().isActive)
            {
                target = item.transform;
            }
        }

        float step = cameraFollowSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target.position, step);
    }
}
