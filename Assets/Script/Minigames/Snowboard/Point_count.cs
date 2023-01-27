using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_count : MonoBehaviour
{

    public string textoScore;
    public int score;

    void Start()
    {
        score = 0;
        textoScore = score.ToString();
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
