using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExecutor : MonoBehaviour
{
    //public List<Ability> abilities = new List<Ability>();
    public List<AbilityInstance> activeAbilities = new List<AbilityInstance>();

    void Update()
    {
        if (activeAbilities.Count == 0) return;
        
        float deltaTime = Time.deltaTime;
        for (int i = activeAbilities.Count - 1; i >= 0; i--)
        {
            if (activeAbilities[i].Update(deltaTime))
            {
                activeAbilities.RemoveAt(i);
            }
        }
    }
    
    public void AddAbility(Ability ability, Enemy enemyTarget)
    {
        activeAbilities.Add(new AbilityInstance(ability, enemyTarget));
    }
}
