using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public new string name;
    public float damage;
    public float duration;
    public int staminaRequired;
    public bool isActive;
    public bool targetRequired;

    public virtual void Activate(Enemy enemy) { }
    public virtual void Activate() { }
    public virtual void ExecuteUpdate() { }
}
