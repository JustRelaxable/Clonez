using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    // When Player (active clone) touch Ground Destroy

    public GameObject clonePrefab;
    MainGame gameManager;
    CloneManagement cloneManagment;

    private void Start()
    {
        gameManager = FindObjectOfType<MainGame>();
        cloneManagment = FindObjectOfType<CloneManagement>();
    }

    private void OnCollisionEnter(Collision collision)
    {


        GameObject clone = collision.gameObject;
        if (clone.GetComponent<ThirdPersonUserControl>())
        {
            Destroy(collision.gameObject);
            RestartProcess();
        }

       
    }

    private void RestartProcess()
    {
        DestroyClonesAndSetNewCamera();
        Restart();


    }

    private void Restart()
    {
        GameObject clone = Instantiate(clonePrefab, FindObjectOfType<CheckPoint>().restartPoint, Quaternion.identity);

        gameManager.clones.Add(clone.GetComponent<ThirdPersonUserControl>()); //  üst satırda yaratılan klonun clones listesine eklenmesi için
        gameManager.SetActiveUserControl(gameManager.clones.IndexOf(clone.GetComponent<ThirdPersonUserControl>()));// aktif klonu clone olarak değiştiriyor

        clone.GetComponent<ThirdPersonUserControl>().isActive = true;
        clone.GetComponent<ThirdPersonUserControl>().CheckActive();
    }

    private void DestroyClonesAndSetNewCamera()
    {
        GameObject[] clones = GameObject.FindGameObjectsWithTag("clone");
        foreach (GameObject cln in clones)
        {
            Destroy(cln);
        }
        FindObjectOfType<CameraFollow>().AttachCameraTargetToCameraBase();
    }

  
}




//gameManager.GetComponent<MainGame>().activeUserControl = clone.GetComponent<ThirdPersonUserControl>();// yarı çalışıyo
//cloneManagment.CheckActive();
//ThirdPersonUserControl activeUserControl = clone.GetComponent<ThirdPersonUserControl>();
//ThirdPersonUserControl activeUserControl = gameManager.activeUserControl;
// gameManager.SetActiveUserControl(gameManager.clones.IndexOf(activeUserControl) );
//gameManager.SetActiveUserControl(1);

//FindObjectOfType<CameraFollow>().cameraTarget= GameObject.FindGameObjectWithTag("camrafollow");