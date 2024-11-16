using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public class SelectorItem : MonoBehaviour
{
    public Color baseColor;
    public Color hoverColor;

    private Image background;
    void Awake()
    {
        background = GetComponent<Image>();
        background.color = baseColor;
    }

    public void Select()
    {
        background.color = hoverColor;
    }

    public void Deselect()
    {
        background.color = baseColor;
    }
}
