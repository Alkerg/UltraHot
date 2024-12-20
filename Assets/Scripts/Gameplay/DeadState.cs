using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        enemy.navMeshAgent.isStopped = true;
        enemy.animator.SetBool("isDead",true);
        enemy.StartCoroutine(DeactivateEnemy(enemy));
    }

    public void UpdateState(Enemy enemy)
    {
        
    }

    public void ExitState(Enemy enemy)
    {
        
    }

    public IEnumerator DeactivateEnemy(Enemy enemy)
    {
        yield return new WaitForSeconds(2.61f);
        enemy.gameObject.SetActive(false);
    }
}
