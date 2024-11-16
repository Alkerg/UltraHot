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
    //private Vector2 mousePosition;
    //private float currentAngle;
    private IteratorObjects<GameObject, Ability> iteratorAbilities;
    private IteratorObjects<GameObject, Weapon> iteratorWeapons;
    //private int indexSelection;
    //private int prevIndexSelection;
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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (WeaponManager.usingWeapons)
            {
                activeWeaponSelector = false;
                activeAbilitySelector = true;
                weaponSelector.SetActive(activeWeaponSelector);
                abilitySelector.SetActive(activeAbilitySelector);
                WeaponManager.usingWeapons = false;
                AbilityManager.usingAbilities = true;
                abilityItems[iteratorAbilities.GetCurrentIndex()].GetComponent<SelectorItem>().Select();    //Patch
            } else if (AbilityManager.usingAbilities)
            {
                activeAbilitySelector = false;
                activeWeaponSelector = true;
                abilitySelector.SetActive(activeAbilitySelector);
                weaponSelector.SetActive(activeWeaponSelector);
                AbilityManager.usingAbilities = false;
                WeaponManager.usingWeapons = true;
                weaponItems[iteratorWeapons.GetCurrentIndex()].GetComponent<SelectorItem>().Select();   //Patch
            }
            /*activeAbilitySelector = !activeAbilitySelector;
            activeWeaponSelector = !activeWeaponSelector;

            AbilityManager.usingAbilities = !AbilityManager.usingAbilities;
            WeaponManager.usingWeapons = !WeaponManager.usingWeapons;

            abilitySelector.SetActive(activeAbilitySelector);
            weaponSelector.SetActive(activeWeaponSelector);*/

            /*if (activeAbilitySelector)
            {
                disableCoroutine = DisableSelectorAfterSeconds(2f);
                StartCoroutine(disableCoroutine);
            }
            else
            {
                StopCoroutine(disableCoroutine);
            }*/
        }

        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
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
            }

        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
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
            }

        }


        if (activeAbilitySelector)
        {
           /* mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            currentAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            currentAngle = (currentAngle + 360) % 360;
            indexSelection = (int)currentAngle / 90;*/

        }
    }

    IEnumerator DisableSelectorAfterSeconds(float time)
    {
        
        yield return new WaitForSeconds(time);
        activeAbilitySelector = false;
        abilitySelector.SetActive(false);
        Debug.Log("disabled automatically");
    }
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
