using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer musicPlayer;
    public static float musicLevel = 1;
    public Slider musicSlider;

    private void Awake()
    {
        if(musicPlayer == null)
        {
            musicPlayer = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        if(musicSlider != null)
        {
            musicLevel = musicSlider.value;
        }

        else
        {

        }
    }

    
    void Update()
    {
        
    }
    

    public void ChangeMusicLevel()
    {
        musicLevel = musicSlider.value;
    }
}
