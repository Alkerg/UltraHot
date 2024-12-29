using UnityEngine;

public class test2 : MonoBehaviour
{
    float distancePerFrame = 5;
    float counter = 0;
    void Start()
    {
    }
    void Update()
    {
          
        counter += Time.deltaTime;
        if (counter <= 1) transform.Translate(0, 0, distancePerFrame);
    }
}
