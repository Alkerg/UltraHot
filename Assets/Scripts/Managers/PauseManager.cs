using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get { return instance; } }
    public static float prevTimeScale = 1f;
    public static bool isGamePaused = false;
    public GameObject pauseMenuPanel;
    
    private static PauseManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        isGamePaused = false;
        Time.timeScale = 1;
    }

    void Start()
    {
    }

    void Update()
    {
        Debug.Log(Time.timeScale);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : prevTimeScale;
        pauseMenuPanel.SetActive(isGamePaused);
        Cursor.visible = isGamePaused;

    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        isGamePaused = false;
        Time.timeScale = prevTimeScale;
        Cursor.visible = false;
    }

    public void ExitLevel()
    {
        ScenesManager.LoadGameScene(0);
    }
}
