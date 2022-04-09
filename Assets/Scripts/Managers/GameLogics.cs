using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogics : MonoBehaviour
{
    public static int mode = 1;
    public static string name = "";

    public void ZenMode() {
        mode = 1;
        Debug.Log(mode);
    }

    public void WaveMode() {
        mode = 2;
        Debug.Log(mode);
    }

    public void InputName(string input) {
        name = input;
        Debug.Log(name);
    }
}
