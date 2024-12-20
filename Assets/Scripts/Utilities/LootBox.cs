using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    public float health = 50;
    public List<GameObject> lootPrefabs;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            int randomIndex = Random.Range(0, lootPrefabs.Count);
            Debug.Log(randomIndex);
            GameObject objectToSpawn = lootPrefabs[randomIndex];
            Debug.Log(objectToSpawn.name);
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
