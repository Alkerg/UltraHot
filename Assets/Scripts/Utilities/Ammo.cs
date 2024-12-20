using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private float bullets = 10;

    public float getBullets()
    {
        return bullets;
    }
}
