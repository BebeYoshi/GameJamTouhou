using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_UI : MonoBehaviour
{
    public GameObject npcPanel;
    [SerializeField] private string tipo = "";
    public Button buyButton;


    void Start(){
        buyButton.interactable = false;
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleCanvas(){
        if(!npcPanel.activeSelf){
            npcPanel.SetActive(true);
            CheckScore();
        }else{
            npcPanel.SetActive(false);
        }
    }

    public void CheckScore(){
        switch(tipo){
            case "Snowboard":
                if(Info_Player.score_snowboard >= 2000 && Info_Player.item_snowboard == false){
                    Debug.Log(Info_Player.score_snowboard);
                    buyButton.interactable = true;
                }
            break;
            case "Snowfight":

            break;
            case "Cooking":

            break;
            case "Snowman":

            break;
        }

    }

    public void buyItem(){
        Info_Player.item_snowboard = true;
        buyButton.interactable = false;
    }

    public void GambADDPOINTS(){
        Info_Player.score_snowboard = 2001;
        Debug.Log(Info_Player.item_snowboard);
        CheckScore();
    }

}