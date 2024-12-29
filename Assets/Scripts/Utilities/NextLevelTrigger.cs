using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(LevelManager.levelComplete) ScenesManager.LoadGameScene(2);
    }
}
