using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreClass : MonoBehaviour
{
    public string name;
    public float score;

    public ScoreClass(string newname, float newscore) {
        name = newname;
        score = newscore;
    }
}
