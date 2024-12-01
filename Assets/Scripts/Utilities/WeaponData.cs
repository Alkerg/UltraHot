using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName="WeaponDataScriptableObject", menuName="WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float weaponDamage;
    public float ammo;
    public float currentBullets;
    public float maxCurrentBullets;
}
