using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public Text LivesText;
    public static int RemainLives = 20 , StartLives = 20;
    public static lives instance;

    public void DecreaseLive(int live){
        RemainLives -= live;
        LivesText.text = RemainLives.ToString() + " LIVES";
    }

    void Awake(){
        instance = this;
        RemainLives = StartLives;
    }
}
