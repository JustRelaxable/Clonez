using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing; 

public class CloneManagement : MonoBehaviour
{
    public GameObject cloneInstance;
    public GameObject explosionClone;
    GameObject activeClone;
    MainGame gameManager;
    ThirdPersonUserControl activeUserControl;
    CameraCollision cameraCollision;
    public PostProcessProfile myProfile;
    

    private void Awake()
    {
        gameManager = GetComponent<MainGame>();
        cameraCollision = GameObject.FindObjectOfType<CameraCollision>();
        CheckActive();
    }



    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButton(1) && Input.GetMouseButtonDown(0))  // farenin sağ ve sol tuşları aynı anda basılıysa 
        {
            CreateClone(); 
        }

        activeUserControl = gameManager.activeUserControl;

        if (Input.GetMouseButton(1))  // farenin sağ tuşu basılıyken
        {
            RotateToClonePos();
            if (Input.mouseScrollDelta.y > 0 && gameManager.clones.IndexOf(activeUserControl) < gameManager.clones.Count - 1) // aktif klonun dizideki sırası dizinin uzunluğundan küçükse
            {
                gameManager.SetActiveUserControl(gameManager.clones.IndexOf(activeUserControl) + 1);  // clones dizisindeki sonraki klonu aktif klon yap
            }

            else if (Input.mouseScrollDelta.y < 0 && !(gameManager.clones.IndexOf(activeUserControl) < 1))  // aktif klonun dizideki sırası dizinin uzunluğundan küçükse
            {
                gameManager.SetActiveUserControl(gameManager.clones.IndexOf(activeUserControl) - 1);   // clones dizisindeki önceki klonu aktif klon yap
            }

            myProfile.GetSetting<DepthOfField>().active = true;
        }

        else
        {
            myProfile.GetSetting<DepthOfField>().active = false;
        }


    }

    private void RotateToClonePos()
    {
        Vector3 dirToLook = (cameraCollision.raycastHit.point - activeClone.transform.position).normalized;
        dirToLook.y = 0;
        activeClone.transform.rotation = Quaternion.LookRotation(dirToLook);
    }

    void CreateClone()  // klon yaratma
    {
        if (0 < gameManager.maxCloneNumber)
        {
            GameObject clone = Instantiate(cloneInstance, cameraCollision.raycastHit.point, Quaternion.identity); // raycastin değdiği yere klon yarat

            gameManager.clones.Add(clone.GetComponent<ThirdPersonUserControl>()); //clones listesine yarattığın klonu ekle çünkü sonra akriveUserController'a bu klonu atamak için
            clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
            clone.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
            gameManager.maxCloneNumber -= 1;
        }
        
        //clone.GetComponent<Animator>().Update(0);
    }

    public void CheckActive()
    {
        activeClone = gameManager.activeUserControl.gameObject;
    }
}
