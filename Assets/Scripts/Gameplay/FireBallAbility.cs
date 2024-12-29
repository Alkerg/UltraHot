using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAbility : Ability
{
    private float counter;
    private Enemy targetEnemy;
    
    void Start()
    {
        
    }
    
    public override void Activate(Enemy enemy)
    {
        isActive = true;
        targetEnemy = enemy;
        counter = duration;
        enemy.TakeDamage(damage);
        targetEnemy.navMeshAgent.isStopped = true;
        enemy.ChangeState(new StunState());
        enemy.animator.SetBool("beingBurned",true);
        enemy.burningVFX.Reinit();
        enemy.burningVFX.Play();
    }

    public override void ExecuteUpdate()
    {
        counter -= Time.deltaTime;
        
        if (targetEnemy.Health <= 0)
        {
            isActive = false;
            targetEnemy.ChangeState(new DeadState());
        }
        if (counter <= 0)
        {
            Deactivate();
        }
    }

    public override void Deactivate()
    {
        isActive = false;
        targetEnemy.navMeshAgent.isStopped = false;
        targetEnemy.ChangeState(new ChasingPlayerState());
        targetEnemy.animator.SetBool("beingBurned",false);
        targetEnemy.burningVFX.Stop();
    }
}
