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
        if (enemy.Health <= 0)
        {
            enemy.ChangeState(new DeadState());
            return;
        }
        Vector3 offset = new Vector3(1.1f, 1.1f, 1.1f);
        Vector3 targetRotation = new Vector3(enemy.player.transform.position.x,enemy.transform.position.y, enemy.player.transform.position.z);
        Vector3 destination = enemy.player.transform.position + offset;
        enemy.navMeshAgent.destination = destination;
        enemy.transform.LookAt(targetRotation);
        float distanceToPlayer = Vector3.Distance(enemy.player.transform.position, enemy.transform.position);
        if (distanceToPlayer <= 2f)
        {
            enemy.ChangeState(new CloseAttackState());
        }
        
    }

    public void ExitState(Enemy enemy)
    {
        
    }
}
