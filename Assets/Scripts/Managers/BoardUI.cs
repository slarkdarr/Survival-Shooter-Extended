using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardUI : MonoBehaviour
{
    public ZenRow zens;
    public WaveRow waves;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameLogics.boardMode == 1) {
            var scores = scoreManager.getHighScoresZen().ToArray();
            for (int i=0;i<scores.Length;i++) {
                var row = Instantiate(zens, transform).GetComponent<ZenRow>();
                row.rank.text = (i+1).ToString();
                row.name.text = scores[i].name;
                row.score.text = scores[i].score.ToString();
            }
        }
        else if (GameLogics.boardMode == 2) {
            var scores = scoreManager.getHighScoresWave().ToArray();
            for (int i=0;i<scores.Length;i++) {
                var row = Instantiate(waves, transform).GetComponent<WaveRow>();
                row.rank.text = (i+1).ToString();
                row.name.text = scores[i].name;
                row.wave.text = scores[i].wave.ToString();
                row.score.text = scores[i].score.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
