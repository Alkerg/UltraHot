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
    public StaminaBar staminaBar;

    private AbilityExecutor abilityExecutor;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
        abilityExecutor = GetComponent<AbilityExecutor>();
        usingAbilities = false;
    }

    void Update()
    {
        if (PauseManager.isGamePaused) return;
        
        if (usingAbilities)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ability currentAbility =  selector.getIteratorAbilities().GetCurrentObject();
                abilityExecutor.ability = currentAbility;
                if (currentAbility.staminaRequired > player.Stamina)
                {
                    Debug.Log("Insufficient stamina");
                    return;
                }
                
                if (!currentAbility.targetRequired)
                {
                    currentAbility.Activate();
                }
                else
                {
                    float targetDistance = 30f;
                    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, targetDistance, targetLayerMask))
                    {
                        Enemy enemyAffected = null;
                        Debug.Log(raycastHit.transform.gameObject.name);
                        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * targetDistance, Color.green,1);
                        if (raycastHit.transform.TryGetComponent(out enemyAffected))
                        {
                            Debug.Log("Enemy script");
                        }
                        
                        currentAbility.Activate(enemyAffected);
                    }
                }
                
                TakeStamina(currentAbility.staminaRequired);
            }
        }
        
    }
    
    public void ShowAbilityContainer(bool show)
    {
        abilityContainer.SetActive(show);
    }

    private void TakeStamina(int staminaRequired)
    {
        player.Stamina -= staminaRequired;
        staminaBar.SetStamina(player.Stamina);
    }

}
