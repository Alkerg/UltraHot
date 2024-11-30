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
        enemy.ChangeState(new StunState());
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
    }
}
