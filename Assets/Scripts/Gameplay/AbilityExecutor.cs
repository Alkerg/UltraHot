using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityExecutor : MonoBehaviour
{
    public Ability ability;
    void Update()
    {
        if (ability.isActive && ability != null)
        {
            ability.ExecuteUpdate();
        }
    }
}
