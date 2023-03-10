using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOverJorge : MonoBehaviour
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
            textoHighScore.SetText("New High Score: " + Info_Player.score_jorge.ToString() + "!");
        }
        else
        {
            textoHighScore.SetText("High Score: " + Info_Player.score_jorge.ToString() + "!");
        }
    }

    public void DialogueGameOver()
    {
        if (Info_Player.score_jorge <= 2000 && Info_Player.tries_jorge <= 5)
        {
            dialogueGameOver.SetText("Ze~, why do I have to dress up Jorge multiple times...");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_jorge <= 2000 && Info_Player.tries_jorge > 5)
        {
            dialogueGameOver.SetText("I hate you Jorge.");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_jorge == 0)
        {
            dialogueGameOver.SetText("Hey! I will give you the answers:, Orbs: Reimu, Sakura Tree: Yuyuko, Swords: Youmu, Gap: Yukari, and of course, the broom is for me!");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_jorge >= 2000)
        {
            dialogueGameOver.SetText("I got a score high enough for the item, also why do I have to dress up Jorge faster each time?");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_jorge >= 3000)
        {
            dialogueGameOver.SetText("Why did we name a snowman Jorge?");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaAngry;
        }
        if (Info_Player.score_jorge >= 5000)
        {
            dialogueGameOver.SetText("Ok, I guess Jorge is cool, ze~");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaHappy;
        }
        if (Info_Player.score_jorge >= 2000 && Info_Player.tries_jorge == 1)
        {
            dialogueGameOver.SetText("I got a score high enough for the item on my first try, guess I'm pretty good at dressing up Jorge");
            personagem.GetComponent<UnityEngine.UI.Image>().sprite = marisaHappy;
        }
    }
}
