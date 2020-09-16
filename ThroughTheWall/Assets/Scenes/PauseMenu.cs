using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused_Q = false;

    public GameObject pauseMenuUI;

//    public GameObject WallScript;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused_Q)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused_Q = false;
//        WallScript.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Paused_Q = true;
//        WallScript.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
//        WallScript.SetActive(true);
    }
}
