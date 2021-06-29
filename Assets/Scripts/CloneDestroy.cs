using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CloneDestroy : MonoBehaviour
{
    ThirdPersonUserControl userControl;
    MainGame gameManager;
    float timer = 10f;

    public static UnityEvent onDestroyClone = new UnityEvent();

    private void Awake()
    {
        userControl = GetComponent<ThirdPersonUserControl>();
        gameManager = GameObject.FindObjectOfType<MainGame>();
    }

    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        if(gameManager.activeUserControl != userControl)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                onDestroyClone.Invoke();
                Destroy(this.gameObject);
                gameManager.clones.Remove(userControl);
                
            }
        }
        else
        {
            timer = 10f;
        }
    }
}
