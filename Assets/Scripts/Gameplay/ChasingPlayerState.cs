using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        
    }

    public void UpdateState(Enemy enemy)
    {
        enemy.navMeshAgent.destination = enemy.player.transform.position;
    }

    public void ExitState(Enemy enemy)
    {
        
    }
}
