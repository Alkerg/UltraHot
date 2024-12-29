using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuideManager : MonoBehaviour
{
    public GameObject guidePanel;
    public TextMeshProUGUI titleMessageTMP;
    public TextMeshProUGUI guideMessageTMP;

    private float duration = 2.5f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowGuide(String titleMesssage, String guideMessage)
    {
        guidePanel.SetActive(true);
        titleMessageTMP.text = titleMesssage;
        guideMessageTMP.text = guideMessage;
        StartCoroutine(WaitAndFadeOut());
    }

    IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(duration);
        guidePanel.SetActive(false);
    }
}
