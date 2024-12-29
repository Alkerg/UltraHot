using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExecutor : MonoBehaviour
{
    public List<Ability> activeAbilities = new List<Ability>();
    //public List<AbilityInstance> activeAbilities = new List<AbilityInstance>();

    void Update()
    {
        if (activeAbilities.Count == 0) return;
        
        for (int i = activeAbilities.Count - 1; i >= 0; i--)
        {
            activeAbilities[i].ExecuteUpdate();
            if (!activeAbilities[i].isActive)
            {
                activeAbilities.Remove(activeAbilities[i]);
            }
        }
    }
    
    public void AddAbility(Ability ability, Enemy enemyTarget)
    {
        //activeAbilities.Add(new AbilityInstance(ability, enemyTarget));
    }
}
