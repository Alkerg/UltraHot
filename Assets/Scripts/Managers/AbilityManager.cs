using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public static bool usingAbilities;
    public LayerMask targetLayerMask;
    public GameObject abilityContainer;
    public List<Ability> abilities = new List<Ability>();
    public Selector selector;
    

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
                Enemy enemyAffected;
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
    
    public void ShowAbilityContainer(bool show)
    {
        abilityContainer.SetActive(show);
    }


}
