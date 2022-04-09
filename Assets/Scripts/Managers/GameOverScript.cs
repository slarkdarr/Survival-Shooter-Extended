using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI wave;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        if (GameLogics.mode == 1) {
            score.text = ScoreManager.score.ToString();
            ScoreManager.AddScoreZen(new ZenScore(GameLogics.name, ScoreManager.score));
        }
        else {
            wave.enabled = true;
            // wave.text = wave;
            score.text = ScoreManager.score.ToString();
            // ScoreManager.AddScoreWave(new ZenScore(GameLogics.name, wave, ScoreManager.score));
        }
    }
}
