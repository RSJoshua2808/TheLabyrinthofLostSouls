using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    public String preMessage = "Soul Time Left: ";
    public float seconds = 100;
    private float maxSeconds = 0.0f;
    private TMP_Text textObject;

    void Start()
    {
        textObject = GetComponent<TMP_Text>();
        maxSeconds = seconds;
    }

    void Update()
    {
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;        
        }
        
        seconds = Mathf.Clamp(seconds, 0.0f, maxSeconds);

        textObject.text = preMessage + (int)(seconds / 60) + ":" + (int)(seconds % 60);
    }
}
