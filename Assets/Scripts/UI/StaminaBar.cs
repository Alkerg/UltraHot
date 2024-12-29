using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI staminaText;
    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
        staminaText.text = stamina.ToString();
    }

    public void SetStamina(int stamina)
    {
        slider.value = stamina;
        staminaText.text = stamina.ToString();
    }
}
