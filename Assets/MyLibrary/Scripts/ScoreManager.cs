using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text winnerText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; //this means current Score Manager
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int _points)
    { 
        score += _points; //score = score + _points;

        int sec = (int)score;
        //float otherSec = sec;
        scoreText.text = "Gold Amount Collected: " + score;

        if (score >= 1000000)
        {
            winnerText.text = "CONGRATS! YOU WON!";
        }


    }
   
}
