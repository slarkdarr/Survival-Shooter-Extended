﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       
    public float restartDelay = 2f;            

    Animator animation;                          
    float restartTimer;                    


    void Awake()
    {
        animation = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            animation.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {   
                SceneManager.LoadScene("GameOver");
                // Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void ShowWarning() {
        animation.SetTrigger("Warning");
    }
}