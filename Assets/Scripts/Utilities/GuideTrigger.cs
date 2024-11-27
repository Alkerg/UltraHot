using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrigger : MonoBehaviour
{
    public GuideManager guideManager;
    public String titleMessage;
    public String guideMessage;
    public void OnTriggerEnter(Collider other)
    {
        guideManager.ShowGuide(titleMessage, guideMessage);
        gameObject.SetActive(false);
    }
}
