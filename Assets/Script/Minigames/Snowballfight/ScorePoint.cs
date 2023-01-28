using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoint : MonoBehaviour
{

    public int score;
    public UIGameOver uiGameOver;
    public TMP_Text textoScore;


    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void Score()
    {
        score += 200;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void FinaldeJogo()
    {
        Info_Player.coins += (score / 25);
        uiGameOver.ToggleCanvas();
        if (Info_Player.score_snowballfight < score)
        {
            Info_Player.score_snowballfight = score;
            uiGameOver.HighScore(true);
        }
        else
        {
            uiGameOver.HighScore(false);
        }
    }
}
