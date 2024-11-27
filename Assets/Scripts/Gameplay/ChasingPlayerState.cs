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
        Vector3 offset = new Vector3(1.1f, 1.1f, 1.1f);
        Vector3 targetRotation = new Vector3(enemy.player.transform.position.x,enemy.transform.position.y, enemy.player.transform.position.z);
        enemy.navMeshAgent.destination = enemy.player.transform.position + offset;
        enemy.transform.LookAt(targetRotation);
    }

    public void ExitState(Enemy enemy)
    {
        
    }
}
