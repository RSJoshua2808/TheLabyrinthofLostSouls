using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseSection;

    public GameObject healthBar;


    void Start()
    {
    
    }

    public void Lose()
    {
        Debug.Log("You have Lost!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loseSection.SetActive(true);
        healthBar.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Main Menu");
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("Menu UI");
    }

    public void QuitGame()
    {
#if (UNITY_EDITOR)
        Debug.Log("Quiting Play Mode");
        EditorApplication.ExitPlaymode();
#else
        Debug.Log("Quitting Build");
        Application.Quit();
#endif
    }
}
