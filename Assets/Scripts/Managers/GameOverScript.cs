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
            score.text = "Score: " + ScoreManager.score.ToString();
            ScoreManager.AddScoreZen(new ZenScore(GameLogics.name, ScoreManager.score));
        }
        else if (GameLogics.mode == 2) {
            wave.enabled = true;
            wave.text = "Wave: " + WaveManager.waveNum.ToString();
            score.text = "Score: " + ScoreManager.score.ToString();
            ScoreManager.AddScoreWave(new WaveScore(GameLogics.name, WaveManager.waveNum, ScoreManager.score));
            Debug.Log(ScoreManager.waveScores[0].name);
            Debug.Log(ScoreManager.waveScores[0].wave);
            Debug.Log(ScoreManager.waveScores[0].score);
        }
    }
}
