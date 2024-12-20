using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] private int health = 25;

    public int getHealth()
    {
        return health;
    }
}
