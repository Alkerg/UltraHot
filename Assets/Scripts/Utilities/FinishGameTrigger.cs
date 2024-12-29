using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameTrigger : MonoBehaviour
{
    public GameObject finishGamePanel;
    public AudioClip finishGameSound;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.levelComplete)
        {
            LevelManager.isGameFinished = true;
            finishGamePanel.SetActive(true);
            audioSource.clip = finishGameSound;
            audioSource.Play();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}
