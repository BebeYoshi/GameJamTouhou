using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigames_UI : MonoBehaviour
{
    public GameObject minigamesPanel;
    public TMP_Text highScoreJorge;
    public TMP_Text highScoreSnowboard;
    public TMP_Text highScoreSnowballfight;
    public TMP_Text highScoreCooking;
    public GameObject moedas;


    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleCanvas(){
        if(!minigamesPanel.activeSelf){
            minigamesPanel.SetActive(true);
            highScoreJorge.SetText("Highscore: " + Info_Player.score_jorge.ToString());
            highScoreSnowboard.SetText("Highscore: " + Info_Player.score_snowboard.ToString());
            highScoreSnowballfight.SetText("Highscore: " + Info_Player.score_snowballfight.ToString());
            highScoreCooking.SetText("Highscore: " + Info_Player.score_sopa.ToString());
            moedas.SetActive(false);
        }else{
            minigamesPanel.SetActive(false);
            moedas.SetActive(true);
        }
    }
}
