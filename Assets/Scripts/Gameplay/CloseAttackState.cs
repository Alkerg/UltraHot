using System.Collections;
using UnityEngine;

public class CloseAttackState : IEnemyState
{
    private Coroutine attackCoroutine;
    public void EnterState(Enemy enemy)
    {
        enemy.animator.SetBool("isCloseToPunch",true);
        attackCoroutine = enemy.StartCoroutine(AttackRoutine(enemy));
    }

    public void UpdateState(Enemy enemy)
    {
        if (enemy.Health <= 0)
        {
            enemy.ChangeState(new DeadState());
            return;
        }
        Vector3 targetRotation = new Vector3(enemy.player.transform.position.x,enemy.transform.position.y, enemy.player.transform.position.z);
        enemy.transform.LookAt(targetRotation);
        
        float distanceToPlayer = Vector3.Distance(enemy.player.transform.position, enemy.transform.position);
        
        if (distanceToPlayer > 2f)
        {
            enemy.ChangeState(new ChasingPlayerState());
        }
    }

    public void ExitState(Enemy enemy)
    {
        enemy.animator.SetBool("isCloseToPunch",false);
        enemy.StopCoroutine(attackCoroutine);
        attackCoroutine = null;
    }
    
    private IEnumerator AttackRoutine(Enemy enemy)
    {
        while (true)
        {
            enemy.player.TakeDamage(15);
            yield return new WaitForSeconds(1.0f);
        }
    }
    
}
