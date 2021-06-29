using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    // aktif klona kullanıcı kontrollerini atamak için oluşturulmuş. 
    //NOT: camera follow obj burada ayarlanıyor

    Transform startPoint;
    public int maxCloneNumber = 0;
    int startCloneNumber;
    public ThirdPersonUserControl activeUserControl;
    public List<ThirdPersonUserControl> clones;
    public CameraFollow cameraBaseFollow;
    public static Vector3 lastCheckPointPos;

    private void Awake()
    {
    }
    void Start()
    {
        SetActiveClone();
        lastCheckPointPos = activeUserControl.gameObject.transform.position;
        //startPoint.position = lastCheckPointPos;
        startCloneNumber = maxCloneNumber;
    }

    private void SetActiveClone()
    {
        clones.Add(activeUserControl);
    }



    // Update is called once per frame
    void Update()
    {
        //foreach (var clone in clones) // SİLİNEBİLİR
        //{
        //    if (clone==null)
        //    {
        //        clones.Remove(clone);
        //    }
        //}
        for (int clone = 0; clone < clones.Count; clone++) //amed ekledi.  clones listesindeki destroy edilmiş game objectleri listeden çıkarmak için
        {
            if (clones[clone]==null)
            {
                clones.Remove(clones[clone]);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetActiveUserControl(int activeController) // aktif klonu atamak için
    {
        activeUserControl = clones[activeController];
        CheckOnAllClones();
        SetCameraBaseFollowObject();

        foreach (var item in GameObject.FindObjectsOfType<UITrigger>())
        {
            item.ChangeTarget(activeUserControl.gameObject.GetComponent<CapsuleCollider>()); 
        }
    }

    public void CheckOnAllClones()
    {
        foreach (var clone in clones)
        {
            clone.Invoke("CheckActive",0f);
        }

        GetComponent<CloneManagement>().Invoke("CheckActive",0);
    }
    
    void SetCameraBaseFollowObject()    //Prefab içerisindeki takip edilmesi gereken noktayı bulma
    {
        //cameraBaseFollow.cameraTarget = activeUserControl.gameObject.transform.GetChild(1).gameObject;
    }
}
