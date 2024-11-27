using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColor : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{

    public TextMeshProUGUI TMP;
    public AudioSource audioSource;
    public Color defaultColor;
    public Color hoverColor;
    public Color clickColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TMP.color = hoverColor;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TMP.color = defaultColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TMP.color = clickColor;
    }
}
