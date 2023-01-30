using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending_UI : MonoBehaviour
{
    public TMP_Text highScoreJorge;
    public TMP_Text highScoreSnowboard;
    public TMP_Text highScoreSnowballfight;
    public TMP_Text highScoreCooking;
    public TMP_Text triesJorge;
    public TMP_Text triesSnowboard;
    public TMP_Text triesSnowballfight;
    public TMP_Text triesCooking;
    public GameObject statisticsPanel;
    void Start()
    {
            triesJorge.SetText("Total Tries: " + Info_Player.tries_jorge.ToString());
            triesSnowboard.SetText("Total Tries: " + Info_Player.tries_snowboard.ToString());
            triesSnowballfight.SetText("Total Tries: " + Info_Player.tries_snowballfight.ToString());
            triesCooking.SetText("Total Tries: " + Info_Player.tries_sopa.ToString());
        
    }

    public void ToggleCanvas(){
        if(!statisticsPanel.activeSelf){
            statisticsPanel.SetActive(true);
            highScoreJorge.SetText("Highscore: " + Info_Player.score_jorge.ToString());
            highScoreSnowboard.SetText("Highscore: " + Info_Player.score_snowboard.ToString());
            highScoreSnowballfight.SetText("Highscore: " + Info_Player.score_snowballfight.ToString());
            highScoreCooking.SetText("Highscore: " + Info_Player.score_sopa.ToString());
        }
        else{
            statisticsPanel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
