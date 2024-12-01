using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponManager : MonoBehaviour
{
    public static bool usingWeapons;
    public TextMeshProUGUI ammoTMP;
    public GameObject weaponContainer;
    public List<Weapon> weapons = new List<Weapon>();
    public Selector selector;
    
    void Start()
    {
        usingWeapons = true;
    }

    void Update()
    {
        if (PauseManager.isGamePaused) return;
        
        if (usingWeapons)
        {
            //Shoot bullets
            if (Input.GetMouseButtonDown(0))
            {
                Weapon weapon = selector.getIteratorWeapons().GetCurrentObject();
                if (weapon)
                {
                    weapon.Shoot();
                    UpdateTMP(weapon);
                }
            }
            
            //Reload weapon
            if (Input.GetKeyDown(KeyCode.R))
            {
                Weapon weapon = selector.getIteratorWeapons().GetCurrentObject();
                if (weapon)
                {
                    weapon.Reload();
                    UpdateTMP(weapon);
                }
            }
            
            //Drop weapon
            /*if (Input.GetKey(KeyCode.F))
            {
                Weapon weapon = selector.getIteratorWeapons().GetCurrentObject();
                if (weapon)
                {
                    weapon.Drop();
                    weapons.Remove(weapon);
                    StartCoroutine(Wait(.04f, Time.timeScale));
                }

            }*/
        }
    }

    public void ShowWeaponContainer(bool show)
    {
        weaponContainer.SetActive(show);
    }

    public void ShowAmmoTMP(bool show)
    {
        ammoTMP.gameObject.SetActive(show);
    }

    public void UpdateTMP(Weapon weapon)
    {
        ammoTMP.text = weapon.currentBullets.ToString() + "/" + weapon.ammo.ToString();
    }
    
    IEnumerator Wait(float time, float prevTimeScale)
    {
        //Return to normal speed temporarily
        Time.timeScale = 1;
        yield return new WaitForSeconds(time);
        Time.timeScale = prevTimeScale;
    }
}
