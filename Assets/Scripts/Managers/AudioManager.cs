using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public bool isSFXMuted = false;
    public bool isMusicMuted = false;

    private void Awake()
    {
        audioMixer.SetFloat("Pitch", 0.776f);
        audioMixer.SetFloat("SFXVolume", 0f);
        audioMixer.SetFloat("MusicVolume", 0f);
    }

    public void ChangeSFXVolume()
    {
        if (!isSFXMuted) audioMixer.SetFloat("SFXVolume", -80f);
        else audioMixer.SetFloat("SFXVolume", 0f);
        
        isSFXMuted = !isSFXMuted;
    }
    
    public void ChangeMusicVolume()
    {
        if (!isMusicMuted) audioMixer.SetFloat("MusicVolume", -80f);
        else audioMixer.SetFloat("MusicVolume", 0f);
        
        isMusicMuted = !isMusicMuted;
    }
}
