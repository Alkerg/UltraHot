using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExecutor : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();
    void Update()
    {
        if (abilities.Count == 0) return;
        
        for(int i=0; i<abilities.Count; i++)    // plain loop to prevent iterator errors
        {
            if (abilities[i] != null)
            {
                if (abilities[i].isActive)
                {
                    abilities[i].ExecuteUpdate();
                }else if (!abilities[i].isActive)
                {
                    abilities.Remove(abilities[i]);
                }
                
            }
        }

    }
}
