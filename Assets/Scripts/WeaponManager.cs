using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static bool usingWeapons;
    public List<Weapon> weapons = new List<Weapon>();

    void Start()
    {
        usingWeapons = true;
    }

    void Update()
    {
        
    }
}
