using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int stamina = 25;

    public int getStamina()
    {
        return stamina;
    }
    
}
