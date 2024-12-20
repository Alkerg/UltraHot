using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUtilitiesManager : MonoBehaviour
{
    private Player player;
    public AudioSource audioSource;
    public AudioClip pickUpWeaponSound;
    public AudioClip pickupPotionSound;
    public AudioClip pickupFAKSound;
    
    void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ammo ammo))
        {
            WeaponManager weaponManager = GetComponent<WeaponManager>();
            Weapon currentWeapon = weaponManager.selector.getIteratorWeapons().GetCurrentObject();
            
            if (other.CompareTag("PistolAmmo")) weaponManager.weapons[0].ammo += ammo.getBullets();
            if (other.CompareTag("ShotGunAmmo"))  weaponManager.weapons[1].ammo += ammo.getBullets();
            
            weaponManager.UpdateTMP(currentWeapon);
            audioSource.PlayOneShot(pickUpWeaponSound);
            other.gameObject.SetActive(false);
        }
            

        if (other.CompareTag("Potion"))
        {
            AbilityManager abilityManager  = GetComponent<AbilityManager>();
            Potion potion = other.gameObject.GetComponent<Potion>();
            int staminaToFill = player.MaxStamina - player.Stamina;
            int staminaPotion = potion.getStamina();
            if (staminaToFill >= staminaPotion)
            {
                player.Stamina += staminaPotion;
            }
            else
            {
                player.Stamina = player.MaxStamina;
            }
            abilityManager.staminaBar.SetStamina(player.Stamina);
            audioSource.PlayOneShot(pickupPotionSound);
            other.gameObject.SetActive(false);
        }
        
        if (other.CompareTag("FAK"))
        {
            FirstAidKit fak = other.gameObject.GetComponent<FirstAidKit>();
            int healthToFill = player.MaxHealth - player.Health;
            int healthFAK = fak.getHealth();
            if (healthToFill >= healthFAK)
            {
                player.Health += healthFAK;
            }
            else
            {
                player.Health = player.MaxHealth;
            }
            player.healthBar.SetHealth(player.Health);
            audioSource.PlayOneShot(pickupFAKSound);
            other.gameObject.SetActive(false);
        }
    }
}
