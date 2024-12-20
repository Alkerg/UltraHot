using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public ParticleSystem explosion;
    public float explosionRadius;
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Instantiate(explosion,transform.position,Quaternion.Euler(-90f,0f,0f));
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] objectsAffected = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider obj in objectsAffected)
        {
            if (obj.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(damage);
            }
            if (obj.TryGetComponent(out LootBox lootBox))
            {
                lootBox.TakeDamage(damage);
            }
        }
        gameObject.SetActive(false);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
