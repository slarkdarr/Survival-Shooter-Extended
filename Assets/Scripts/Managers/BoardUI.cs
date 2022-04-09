using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardUI : MonoBehaviour
{
    public BoardRow rows;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameLogics.boardMode == 1) {
            var scores = scoreManager.getHighScoresZen().ToArray();
            for (int i=0;i<scores.Length;i++) {
                var row = Instantiate(rows, transform).GetComponent<BoardRow>();
                row.rank.text = (i+1).ToString();
                row.name.text = scores[i].name;
                row.score.text = scores[i].score.ToString();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
