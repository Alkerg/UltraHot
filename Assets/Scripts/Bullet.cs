using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 14f;
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

        if (collision.gameObject.CompareTag("RedGuy"))
        {
            trailRenderer.Clear();
            gameObject.SetActive(false);
            collision.GetComponent<RedGuy>().TakeDamage(20);
        }
    }

}
