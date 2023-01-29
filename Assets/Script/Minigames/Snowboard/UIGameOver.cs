using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{

    public TMP_Text textoHighScore;
    public TMP_Text dialogueGameOver;

    public GameObject painel;

    public void ToggleCanvas()
    {
        if(!painel.activeSelf)
        {
            painel.SetActive(true);
            DialogueGameOver();
        }
        else
        {
            painel.SetActive(false);
        }
    }

    public void HighScore(bool newHighScore)
    {
        if(newHighScore)
        {
            textoHighScore.SetText("New High Score: " + Info_Player.score_snowboard.ToString() + "!");
        }
        else
        {
            textoHighScore.SetText("High Score: " + Info_Player.score_snowboard.ToString() + "!");
        }
    }

    public void DialogueGameOver()
    {
        if (Info_Player.score_snowboard == 0)
        {
            dialogueGameOver.SetText("I should try dodging her snowball by pressing DOWN and shooting her with snowball by pressing Mouse1.");
        }
        if (Info_Player.score_snowboard <= 2000 && Info_Player.tries_snowboard <= 5)
        {
            dialogueGameOver.SetText("Ugh, that little fairy gets on my nerves sometimes...");
        }
        if (Info_Player.score_snowboard <= 2000 && Info_Player.tries_snowboard > 5)
        {
            dialogueGameOver.SetText("STOP DODGING, LET ME SAVE THE SPRING!!");
        }
        if (Info_Player.score_snowboard >= 2000 && Info_Player.tries_snowboard == 1)
        {
            dialogueGameOver.SetText("First try, piece of cake!");
        }
        if (Info_Player.score_snowboard >= 2000)
        {
            dialogueGameOver.SetText("Why is she so fast...");
        }
        if (Info_Player.score_snowboard >= 3000)
        {
            dialogueGameOver.SetText("No matter how many times she is defeated, she keeps coming back stronger...");
        }
        if (Info_Player.score_snowboard >= 5000)
        {
            dialogueGameOver.SetText("I have better things to do.");
        }
    }
}
