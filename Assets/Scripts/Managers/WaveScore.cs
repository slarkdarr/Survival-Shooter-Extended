using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WaveScore : MonoBehaviour
{
    public string name;
    public int wave;
    public float score;

    public WaveScore(string newname, int newwave, float newscore) {
        name = newname;
        wave = newwave;
        score = newscore;
    }
}

