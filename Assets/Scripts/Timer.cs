using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 100;

    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        
        
        }
       




    }
}
