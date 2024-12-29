using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class test1 : MonoBehaviour
{
    float distancePerSecond = 5;
    float counter = 0;
    void Start()
    {
        
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(counter<=1) transform.Translate(0, 0, distancePerSecond * Time.deltaTime);
    }
}
