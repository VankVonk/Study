using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text Score;
    public static int points = 0;

    private void Update()
    {
        Score.text = points + " очков ";
    }
}
