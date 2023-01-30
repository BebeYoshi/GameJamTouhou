using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreJorge : MonoBehaviour
{

    public int score;
    public UIGameOverJorge uiGameOver;
    public GameObject tip;
    public TMP_Text textoScore;


    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
        if (Info_Player.tries_jorge == 0 || Info_Player.score_jorge < 1000)
        {
            StartCoroutine(GiveTip());
        }
    }

    public void Score(int value)
    {
        score += value;
        textoScore.SetText("Score: " + score.ToString());
    }

    public void FinaldeJogo()
    {
        Info_Player.coins += (score / 50);
        uiGameOver.ToggleCanvas();
        Info_Player.tries_jorge++;
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

    IEnumerator GiveTip()
    {
        tip.SetActive(true);
        yield return new WaitForSeconds(5f);
        tip.SetActive(false);
    }
}
