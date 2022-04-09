using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static List<ZenScore> zenScores = new List<ZenScore>();
    public static List<WaveScore> waveScores = new List<WaveScore>();

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_01")) {
            text.text = "Score: " + score;
        }
    }

    public IEnumerable<ZenScore> getHighScoresZen() {
        return zenScores.OrderByDescending(x => x.score);
    }

    public static void AddScoreZen(ZenScore score) {
        zenScores.Add(score);
    }

    public static void AddScoreWave(WaveScore score) {
        waveScores.Add(score);
    }
}
