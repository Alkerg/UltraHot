using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int enemiesAlive = 5;
    public static bool isGameOver = false;
    public static bool levelComplete = false;
    public static bool isGameFinished = false;
    public GameObject door;
    public GameObject gameOverPanel;
    public Player player;
    
    
    private void Awake()
    {
        isGameOver = false;
        levelComplete = false;
        isGameFinished = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver) return;
        if (!isGameOver)
        {
            if (enemiesAlive <= 0)
            {
                levelComplete = true;
                door.SetActive(false);
            }
            
            if (player.Health <= 0)
            {
                isGameOver = true;
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
}
