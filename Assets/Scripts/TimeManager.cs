using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowDownFactor = 0.02f;
    public float slowDownLenght = 2f;


    void Update()
    {
        /*
        Time.timeScale += (1 / slowDownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);

        Debug.Log(Time.timeScale);
        */
    }
    private void FixedUpdate()
    {

    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        //Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }
}
