using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    public float damage;
    public float duration;
    public float staminaRequired;

    public virtual void Activate(Enemy enemy) { }

}
