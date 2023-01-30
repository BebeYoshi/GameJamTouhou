using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOverCooking : MonoBehaviour
{

    public TMP_Text textoHighScore;

    public TMP_Text dialogueGameOver;

    public Sprite marisa;
    public Sprite reimu;

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
            textoHighScore.SetText("New High Score: " + Info_Player.score_sopa.ToString() + "!");
        }
        else
        {
            textoHighScore.SetText("High Score: " + Info_Player.score_sopa.ToString() + "!");
        }
    }

    public void DialogueGameOver()
    {
        if (Info_Player.score_sopa <= 2000 && Info_Player.tries_sopa <= 5)
        {
            dialogueGameOver.SetText("I guess I am not that good at cooking...");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisa;
        }
        if (Info_Player.score_sopa <= 2000 && Info_Player.tries_sopa > 5)
        {
            dialogueGameOver.SetText("Hmm... I think that stealing a soup is easier than making one!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisa;
        }
        if (Info_Player.score_sopa == 0)
        {
            dialogueGameOver.SetText("You should follow what Shinmyoumaru is saying!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisa;
        }
        if (Info_Player.score_sopa >= 2000)
        {
            dialogueGameOver.SetText("We got a score high enough for the item, also this soup smells delicious!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = reimu;
        }
        if (Info_Player.score_sopa >= 3000)
        {
            dialogueGameOver.SetText("I love cooking! It warms my soul in this freezing winter!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = reimu;
        }
        if (Info_Player.score_sopa >= 5000)
        {
            dialogueGameOver.SetText("Hey Reimu, I think this is enough... Remember we gotta save spring!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisa;
        }
        if (Info_Player.score_sopa >= 2000 && Info_Player.tries_sopa == 1)
        {
            dialogueGameOver.SetText("We got a score high enough for the item on the first try! See Marisa? Cooking is easy!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = reimu;
        }
        if (Info_Player.score_sopa >= 5000 && Info_Player.tries_sopa == 1)
        {
            dialogueGameOver.SetText("Fazer uma sopa fifififi, fazer uma sopa pa nois!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisa;
        }
    }
}
