using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance { get { return instance; } }
    public int poolSize = 5;
    public GameObject bulletPrefab;

    private static BulletPool instance;
    private List<GameObject> bulletPool = new List<GameObject>();

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
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
            bullet.transform.parent = transform;
        }
            
    }

    public GameObject getBullet()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(!bulletPool[i].activeSelf)
            {
                bulletPool[i].SetActive(true);
                return bulletPool[i];
            }
        }
        return null;
    }
}
