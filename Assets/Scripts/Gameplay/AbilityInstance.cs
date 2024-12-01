using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInstance
{
    public Ability ability;
    public Enemy enemyTarget;
    private float timeActive;

    public AbilityInstance(Ability ability, Enemy enemyTarget)
    {
        this.ability = ability;
        this.enemyTarget = enemyTarget;
        this.timeActive = 0;
        ability.Activate(enemyTarget);
    }

    public bool Update(float deltaTime)
    {
        timeActive += deltaTime;
        if (timeActive >= ability.duration)
        {
            ability.Deactivate();
            enemyTarget.abilityAffecting = null;
            return true; // Indica que la habilidad ha terminado.
        }
        return false; // Indica que la habilidad sigue activa.
    }
}
