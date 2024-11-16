using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static bool usingAbilities;
    public List<Ability> abilities = new List<Ability>();
    public LayerMask targetLayerMask;
    private Enemy enemyAffected;

    void Start()
    {
        usingAbilities = false;
    }

    void Update()
    {

        if (usingAbilities)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float targetDistance = 30f;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, targetDistance, targetLayerMask))
                {
                    Debug.Log(raycastHit.transform.gameObject.name);
                    Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * targetDistance, Color.green,1);
                    if (raycastHit.transform.TryGetComponent(out enemyAffected))
                    {
                        Debug.Log("Enemy script");
                    }
                }
            }
        }
        
    }
}
