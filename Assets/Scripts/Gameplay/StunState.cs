using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StunState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        enemy.GetComponent<Outline>().enabled = true;
    }

    public void UpdateState(Enemy enemy)
    { 
        
    }

    public void ExitState(Enemy enemy)
    {
        enemy.GetComponent<Outline>().enabled = false;
    }
}
