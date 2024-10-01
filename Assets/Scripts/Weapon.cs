using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody rb;
    private float dropForce = 23;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public void SeparateFromParent()
    {
        transform.SetParent(null);
    }
    public void Drop()
    {
        SeparateFromParent();
        rb.isKinematic = false; //must be false to apply physics
        rb.interpolation = RigidbodyInterpolation.Interpolate;  //must be changed to interpolate to avoid lagging
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;  //must be changed to continuous to avoid collision bugs
        rb.AddForce(transform.forward * dropForce, ForceMode.Impulse);
    }


}
