using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Retry()
    {
        //Restarts current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {   // Reset game on "Enter" press


        if (Input.GetKeyDown("Enter"))
        {
            Time.timeScale = 1f;

            Retry();
        }

    
    
            
    }

}