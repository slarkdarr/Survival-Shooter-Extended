using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ZenScore : MonoBehaviour
{
    public string name;
    public float score;

    public ZenScore(string newname, float newscore) {
        name = newname;
        score = newscore;
    }
}
