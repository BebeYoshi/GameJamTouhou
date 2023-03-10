using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{

    public TMP_Text textoHighScore;
    public TMP_Text dialogueGameOver;

    public Sprite marisaHappy;
    public Sprite marisaAngry;

    public GameObject painel;
    public GameObject personagem;

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
        if (Info_Player.score_snowboard <= 2000 && Info_Player.tries_snowboard <= 5)
        {
            dialogueGameOver.SetText("Ze~, why is the mountain full of rocks and trees?");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard <= 2000 && Info_Player.tries_snowboard > 5)
        {
            dialogueGameOver.SetText("I hate snowboarding!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard == 0)
        {
            dialogueGameOver.SetText("I should try dodging incoming obstacles with arrow keys...");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard >= 2000)
        {
            dialogueGameOver.SetText("I got a high enough score for the item, also boulders and branches at the same time? Jezz.");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard >= 3000)
        {
            dialogueGameOver.SetText("This mountain is definetly an incident by itself, just look at how many logs there are...");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard >= 5000)
        {
            dialogueGameOver.SetText("Snowboarding is not going to make me a better magician at all.");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_snowboard >= 2000 && Info_Player.tries_snowboard == 1)
        {
            dialogueGameOver.SetText("I got a high enough score for the item on my first try, I am the greatest magician afterall, ze~");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaHappy;
        }
    }
}
