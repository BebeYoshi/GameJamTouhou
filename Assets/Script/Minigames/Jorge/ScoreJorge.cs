using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreJorge : MonoBehaviour
{

    public int score;
    public UIGameOverJorge uiGameOver;
    public TMP_Text textoScore;


    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void Score(int value)
    {
        score += value;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void FinaldeJogo()
    {
        Info_Player.coins += (score / 25);
        uiGameOver.ToggleCanvas();
        if (Info_Player.score_jorge < score)
        {
            Info_Player.score_jorge = score;
            uiGameOver.HighScore(true);
        }
        else
        {
            uiGameOver.HighScore(false);
        }
    }
}
