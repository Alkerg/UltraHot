using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get { return instance; } }
    public int poolSizePistol = 30;
    public int poolSizeShotGun = 30;
    public GameObject bulletPrefab;

    private static BulletPool instance;
    private List<GameObject> bulletPoolPistol = new List<GameObject>();
    private List<GameObject> bulletPoolShotGun = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for(int i = 0; i < poolSizePistol; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>().SetDamage(25);
            bullet.SetActive(false);
            bulletPoolPistol.Add(bullet);
            bullet.transform.parent = transform;
        }
        
        for(int i = 0; i < poolSizeShotGun; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>().SetDamage(40);
            bullet.SetActive(false);
            bulletPoolShotGun.Add(bullet);
            bullet.transform.parent = transform;
        }
            
    }

    public GameObject getBullet(string weaponName)
    {
        switch (weaponName)
        {
            case "Pistol":
                for(int i = 0; i < poolSizePistol; i++)
                {
                    if(!bulletPoolPistol[i].activeSelf)
                    {
                        bulletPoolPistol[i].SetActive(true);
                        return bulletPoolPistol[i];
                    }
                }
                return null;
            case "ShotGun":
                for(int i = 0; i < poolSizeShotGun; i++)
                {
                    if(!bulletPoolShotGun[i].activeSelf)
                    {
                        bulletPoolShotGun[i].SetActive(true);
                        return bulletPoolShotGun[i];
                    }
                }
                return null;
            default:
                return null;
        }
    }
    
}
