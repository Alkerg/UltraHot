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
    }

    public override void ExecuteUpdate()
    {
        counter -= Time.unscaledDeltaTime;
        
        if (counter <= 0)
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        isActive = false;
        targetEnemy.navMeshAgent.isStopped = false;
        targetEnemy.ChangeState(new ChasingPlayerState());
        targetEnemy.animator.SetBool("beingBurned",false);
    }
}
