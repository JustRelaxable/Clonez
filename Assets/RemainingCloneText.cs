using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingCloneText : MonoBehaviour
{
    MainGame gameManager;
    int remainingClone;
    Text remainingCloneText;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<MainGame>();
        remainingClone = gameManager.maxCloneNumber;
        remainingCloneText = GetComponent<Text>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        remainingCloneText.text = "Remaining Clone:" + gameManager.maxCloneNumber;
    }
}
