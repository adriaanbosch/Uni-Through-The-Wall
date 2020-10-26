﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused_Q = false;

    public GameObject pauseMenuUI;
    public GameObject GameoverUI;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameoverUI.SetActive(false);
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
        
        if (this.transform.position.y < -10)
        {
            GameOver();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused_Q = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Paused_Q = true;
    }

    void GameOver()
    {
        GameoverUI.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
