using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Point_count : MonoBehaviour
{

    public int score;
    public GameObject enemySpawner;
    public GameObject tip;
    public UIGameOver uiGameOver;
    public TMP_Text textoScore;

    void Start()
    {
        score = 0;
        textoScore.SetText("Score: " + score.ToString());
        if (Info_Player.tries_snowballfight == 0 || Info_Player.score_snowballfight < 1000)
        {
            StartCoroutine(GiveTip());
        }
    }

    public void CountPoint()
    {
        score += 200;
        textoScore.SetText("Score: " + score.ToString());
    }


    public void FinaldeJogo()
    {
        Destroy(enemySpawner);
        Info_Player.coins += (score / 100);
        Info_Player.tries_snowboard++;
        uiGameOver.ToggleCanvas();
        if (Info_Player.score_snowboard < score)
        {
            Info_Player.score_snowboard = score;
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
