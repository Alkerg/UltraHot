using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float ammo;
    public float currentBullets;
    public float maxCurrentBullets;
    public AudioClip shootSFX;
    public AudioClip reloadSFX;
    
    private AudioSource audioSource;
    private Rigidbody rb;
    private float dropForce = 10;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
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
            audioSource.PlayOneShot(shootSFX);
        }

    }

    public void Reload()
    {
        if (currentBullets < maxCurrentBullets && ammo > 0)
        {
            float bulletsToReload = maxCurrentBullets - currentBullets;
            if (ammo < bulletsToReload)
            {
                currentBullets += ammo;
                ammo = 0;
            }
            else
            {
                ammo -= bulletsToReload;
                currentBullets += bulletsToReload;
            }
            audioSource.PlayOneShot(reloadSFX);
        }
    }
    
}
