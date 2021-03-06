using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public static int waveNum;
    public static int waveWeight;
    public static int waveNumMax;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        waveNum = 1;
        waveNumMax = 9;
        waveWeight = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_01")) {

            if (GameLogics.mode == 1) {
                text.text = "";
            }
            else if (GameLogics.mode == 2) {
                text.text = "Wave: " + waveNum;
            }

        }
        
    }
}
