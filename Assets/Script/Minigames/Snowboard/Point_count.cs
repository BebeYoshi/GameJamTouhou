using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point_count : MonoBehaviour
{

    public int score;
    public TMP_Text textoScore;

    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void CountPoint()
    {
        score += 200;
        textoScore.SetText("Score: " + score.ToString());
    }


    public void FinaldeJogo()
    {
        Debug.Log("Acabou");
        Info_Player.coins += (score / 100);
        if(Info_Player.score_snowboard < score)
        {
            Info_Player.score_snowboard = score;
        }
    }
}
