using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using SuperPupSystems.Helper;

public class WinMenu : MonoBehaviour
{

    void Start()
    {
        Win();
    }

    public void Win()
    {
        Debug.Log("You have WON!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        //SceneManager.LoadSceneAysnc(1);
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Debug.Log("Win Scene");
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("Menu UI");
    }
}

