using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public ParticleSystem explosion;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosion,transform.position,transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
