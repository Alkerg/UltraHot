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
        Vector3 offset = new Vector3(1.1f, 0, 1.1f);
        Vector3 targetRotation = new Vector3(enemy.player.transform.position.x, enemy.transform.position.y, enemy.player.transform.position.z);
        //Vector3 destination = enemy.player.transform.position + offset;
        Vector3 destination = Vector3.MoveTowards(enemy.player.transform.position, enemy.transform.position, 1.6f);
        if (!enemy.navMeshAgent.hasPath) enemy.navMeshAgent.destination = enemy.player.transform.position;
        else enemy.navMeshAgent.destination = destination;
        //Debug.Log(destination);
        enemy.transform.LookAt(targetRotation);
        float distanceToPlayer = Vector3.Distance(enemy.player.transform.position, enemy.transform.position);
        Debug.Log(distanceToPlayer);
        if (distanceToPlayer <= 2.5f)
        {
            enemy.ChangeState(new CloseAttackState());
        }
        
    }

    public void ExitState(Enemy enemy)
    {
        
    }
}
