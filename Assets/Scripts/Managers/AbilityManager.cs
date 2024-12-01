using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                
                if (currentAbility.staminaRequired < player.Stamina && !currentAbility.isActive)
                {
                    abilityExecutor.abilities.Add(currentAbility);

                    if (!currentAbility.targetRequired)
                    {
                        currentAbility.Activate();
                        TakeStamina(currentAbility.staminaRequired);
                    }
                    else if(currentAbility.targetRequired)
                    {
                        float targetDistance = 30f;
                        
                        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, targetDistance, targetLayerMask))
                        {
                            Enemy enemyAffected = null;
                            Debug.Log(raycastHit.transform.gameObject.name);
                            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * targetDistance, Color.green,1);
                            if (raycastHit.transform.TryGetComponent(out enemyAffected))
                            {
                                if (AvailableToAddEffect(enemyAffected))
                                {
                                    Debug.Log("Enemy script");
                                    currentAbility.Activate(enemyAffected);
                                    enemyAffected.abilityAffecting = currentAbility;
                                    TakeStamina(currentAbility.staminaRequired);
                                }
                            }
                        }
                    }
                
                }
                
            }
        }
        
    }

    public bool AvailableToAddEffect(Enemy enemy)
    {
        if (enemy.abilityAffecting == null) return true;
        return false;
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
