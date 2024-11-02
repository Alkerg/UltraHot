using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowDownFactor = 0.02f;
    private float slowDownLenght = 2f;
    public bool isBulletTime;
    public TextMeshProUGUI TMPText;

    void Update()
    {
        /*
        Time.timeScale += (1 / slowDownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);

        Debug.Log(Time.timeScale);
        */
    }


    public void ActivateBulletTime()
    {
        Time.timeScale = slowDownFactor;
        //Time.fixedDeltaTime = Time.timeScale * .02f;
        isBulletTime = true;
        TMPText.text = "Bullet time: On";
    }

    public void DeactivateBulletTime()
    {
        Time.timeScale = 1;
        //Time.fixedDeltaTime = .02f;
        isBulletTime = false;
        TMPText.text = "Bullet time: Off";
    }
}
