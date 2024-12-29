using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 14f;
    private float damage = 10f;
    private TrailRenderer trailRenderer;

    private void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            trailRenderer.Clear();
            collision.GetComponent<Enemy>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("LootBox"))
        {
            trailRenderer.Clear();
            collision.GetComponent<LootBox>().TakeDamage(damage);
            gameObject.SetActive(false);
        }else if (collision.gameObject.CompareTag("ExplosiveBarrel"))
        {
            trailRenderer.Clear();
            collision.GetComponent<ExplosiveBarrel>().Explode();
            gameObject.SetActive(false);
        }
        {
            trailRenderer.Clear();
            gameObject.SetActive(false);
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

}
