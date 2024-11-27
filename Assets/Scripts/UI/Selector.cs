using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public bool activeAbilitySelector;
    public bool activeWeaponSelector;
    public GameObject abilitySelector;
    public GameObject weaponSelector;
    public AbilityManager abilityManager;
    public WeaponManager weaponManager;
    public List<GameObject> abilityItems;
    public List<GameObject> weaponItems;

    private IteratorObjects<GameObject, Ability> iteratorAbilities;
    private IteratorObjects<GameObject, Weapon> iteratorWeapons;
    private IEnumerator disableCoroutine;

    private void Awake()
    {
        
    }
    private void Start()
    {
        iteratorAbilities = new IteratorObjects<GameObject, Ability>(abilityItems, abilityManager.abilities);
        iteratorWeapons = new IteratorObjects<GameObject, Weapon>(weaponItems, weaponManager.weapons);
        activeAbilitySelector = false;
        activeWeaponSelector = false;
        weaponManager.UpdateTMP(iteratorWeapons.GetCurrentObject());
        //disableCoroutine = DisableSelectorAfterSeconds(2f);
    }

    private void Update()
    {
        if (PauseManager.isGamePaused) return;

        if (Input.GetMouseButtonDown(1))
        {
            if (disableCoroutine != null) StopCoroutine(disableCoroutine);

            if (WeaponManager.usingWeapons)
            {
                activeWeaponSelector = false;
                activeAbilitySelector = true;
                weaponSelector.SetActive(activeWeaponSelector);
                abilitySelector.SetActive(activeAbilitySelector);
                WeaponManager.usingWeapons = false;
                AbilityManager.usingAbilities = true;
                abilityItems[iteratorAbilities.GetCurrentIndex()].GetComponent<SelectorItem>().Select();    //Patch
                weaponManager.ShowWeaponContainer(false);
                abilityManager.ShowAbilityContainer(true);
                weaponManager.ShowAmmoTMP(false);

            } else if (AbilityManager.usingAbilities)
            {
                activeAbilitySelector = false;
                activeWeaponSelector = true;
                abilitySelector.SetActive(activeAbilitySelector);
                weaponSelector.SetActive(activeWeaponSelector);
                AbilityManager.usingAbilities = false;
                WeaponManager.usingWeapons = true;
                weaponItems[iteratorWeapons.GetCurrentIndex()].GetComponent<SelectorItem>().Select();   //Patch
                weaponManager.ShowWeaponContainer(true);
                abilityManager.ShowAbilityContainer(false);
                weaponManager.ShowAmmoTMP(true);
            }

            disableCoroutine = DisableSelectorAfterSeconds(2f);
            StartCoroutine(disableCoroutine);
        }

        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (disableCoroutine != null) StopCoroutine(disableCoroutine);

            if (AbilityManager.usingAbilities)
            {
                activeAbilitySelector = true;
                abilitySelector.SetActive(activeAbilitySelector);
                iteratorAbilities.Next();
            }
            if (WeaponManager.usingWeapons)
            {
                activeWeaponSelector = true;
                weaponSelector.SetActive(activeWeaponSelector);
                iteratorWeapons.Next(); 
                weaponManager.UpdateTMP(iteratorWeapons.GetCurrentObject());
            }

            disableCoroutine = DisableSelectorAfterSeconds(2f);
            StartCoroutine(disableCoroutine);

        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (disableCoroutine != null) StopCoroutine(disableCoroutine); 

            if (AbilityManager.usingAbilities)
            {
                activeAbilitySelector = true;
                abilitySelector.SetActive(activeAbilitySelector);
                iteratorAbilities.Previous();
            }
            if (WeaponManager.usingWeapons)
            {
                activeWeaponSelector = true;
                weaponSelector.SetActive(activeWeaponSelector);
                iteratorWeapons.Previous();
                weaponManager.UpdateTMP(iteratorWeapons.GetCurrentObject());
            }

            disableCoroutine = DisableSelectorAfterSeconds(2f);
            StartCoroutine(disableCoroutine);

        }
    }

    IEnumerator DisableSelectorAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("disabled automatically");

        if (activeAbilitySelector)
        {
            activeAbilitySelector = false;
            abilitySelector.SetActive(activeAbilitySelector);
        }else if (activeWeaponSelector)
        {
            activeWeaponSelector = false;
            weaponSelector.SetActive(activeWeaponSelector);
        }

        
    }
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    public IteratorObjects<GameObject, Ability> getIteratorAbilities()
    {
        return iteratorAbilities;
    }

    public IteratorObjects<GameObject, Weapon> getIteratorWeapons()
    {
        return iteratorWeapons;
    }
}
