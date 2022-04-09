using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Level_01");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }
}
