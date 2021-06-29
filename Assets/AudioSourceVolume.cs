using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceVolume : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = MusicPlayer.musicLevel;
    }
}
