using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoint : MonoBehaviour
{

    public int score;
    public UIGameOverBall uiGameOver;
    public GameObject tip;
    public TMP_Text textoScore;


    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
        if(Info_Player.tries_snowballfight == 0 || Info_Player.score_snowballfight < 1000)
        {
            StartCoroutine(GiveTip());
        }
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

    IEnumerator GiveTip()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(5f);
        tip.SetActive(false);
    }
}
