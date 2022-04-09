using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    private List<ScoreClass> scores;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
        scores = new List<ScoreClass>();
    }


    void Update ()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_01")) {
            text.text = "Score: " + score;
        }
    }

    public IEnumerable<ScoreClass> getHighScores() {
        return scores.OrderByDescending(x => x.score);
    }

    public void AddScore(ScoreClass score) {
        scores.Add(score);
    }
}
