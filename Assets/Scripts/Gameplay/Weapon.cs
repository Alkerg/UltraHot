using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float ammo;
    public float currentBullets;
    public float maxCurrentBullets;
    
    private Rigidbody rb;
    private float dropForce = 10;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }
    
    public void Shoot()
    {
        if (currentBullets > 0)
        {
            Vector3 offset = Camera.main.transform.forward.normalized;
            GameObject bullet = BulletPool.Instance.getBullet(weaponName);
            bullet.transform.position = Camera.main.transform.position + offset;
            bullet.transform.rotation = Camera.main.transform.rotation;
            currentBullets -= 1;
            Debug.Log("Current bullets: " + currentBullets + "  Ammo: " + ammo);
        }

    }

    public void Reload()
    {
        if (currentBullets < maxCurrentBullets)
        {
            float bulletsToReload = maxCurrentBullets - currentBullets;
            ammo -= bulletsToReload;
            currentBullets += bulletsToReload;
            Debug.Log("Current bullets: " + currentBullets + "  Ammo: " + ammo);
        }
    }
    
    public void SeparateFromParent()
    {
        transform.SetParent(null);
    }
    
    public void Drop()
    {
        SeparateFromParent();
        rb.isKinematic = false; //must be 'false' to apply physics
        rb.interpolation = RigidbodyInterpolation.Interpolate;  //must be changed to 'interpolate' to avoid lagging
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;  //must be changed to 'continuous' to avoid collision bugs
        //rb.AddForce(transform.forward * dropForce, ForceMode.Impulse);
        rb.AddForce(Camera.main.transform.forward * dropForce, ForceMode.Impulse);    
    }
    
}
