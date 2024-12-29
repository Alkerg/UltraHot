using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BulletTimeAbility : Ability
{
    private float slowDownFactor = 0.01f;
    private float slowDownLenght = 15f;
    public AudioMixer audioMixer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void Activate()
    {
        Time.timeScale = slowDownFactor;
        isActive = true;    
    }

    public override void ExecuteUpdate()
    {
        if (isActive && !PauseManager.isGamePaused)
        {
            if (Time.timeScale != 1)
            {
                Time.timeScale += (1 / slowDownLenght) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
                audioMixer.SetFloat("Pitch",0.45f );
            }
            else
            {
                Deactivate();
            }
            PauseManager.prevTimeScale = Time.timeScale;
        }
    }

    public void Deactivate()
    {
        isActive = false;
        audioMixer.SetFloat("Pitch",0.776f );
        //Debug.Log(Time.timeScale);
    }
}
