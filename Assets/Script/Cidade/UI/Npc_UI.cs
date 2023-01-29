using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Npc_UI : MonoBehaviour
{
    public GameObject npcPanel;
    [SerializeField] private int tipo; //1 = Snowboard, 2 = Snowfight, 3 = Cooking, 4 = Snowman
    public Button buyButton;
    public TMP_Text textoLoja;
    public Moeda moeda;


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
            Debug.Log(Info_Player.totalizador);
        }else{
            npcPanel.SetActive(false);
            moeda.checarItens();
        }
    }

    public void CheckScore(){
        switch(tipo){
            case 0:
                if(Info_Player.score_snowboard >= 2000 && Info_Player.item_snowboard == false && Info_Player.coins >= 200){
                    textoLoja.SetText("In stock!");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_snowboard < 2000){
                    textoLoja.SetText("You should be better at snowboard before buying this!");

                }
                else if(Info_Player.item_snowboard == true){
                    textoLoja.SetText("You already got this!");
                }
                else {
                    textoLoja.SetText("You can't buy this get more coins!");
                }
            break;
            case 1:
              if(Info_Player.score_snowballfight >= 2000 && Info_Player.item_snowfight == false && Info_Player.coins >= 200){
                    textoLoja.SetText("In stock!");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_snowballfight  < 2000){
                    textoLoja.SetText("You should be better at snowboard before buying this!");

                }
                else if(Info_Player.item_snowfight == true){
                    textoLoja.SetText("You already got this!");
                }
                else {
                    textoLoja.SetText("You can't buy this get more coins!");
                }


            break;
            case 2:
            if( Info_Player.item_cooking == false && Info_Player.coins >= 300){
                    textoLoja.SetText("In stock!");
                    buyButton.interactable = true;
                }
                else if(Info_Player.item_cooking == true){
                    textoLoja.SetText("You already got this!");
                }
                else {
                    textoLoja.SetText("You can't buy this get more coins!");
                }


            break;
            case 3:
            if(Info_Player.score_jorge >= 2000 && Info_Player.item_snowman == false && Info_Player.coins >= 200){
                    textoLoja.SetText("In stock!");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_jorge  < 2000){
                    textoLoja.SetText("You should be better at dressing a snowman before buying this!");

                }
                else if(Info_Player.item_snowman == true){
                    textoLoja.SetText("You already got this!");
                }
                else {
                    textoLoja.SetText("You can't buy this get more coins!");
                }
            break;
        }

    }

    public void buyItem(){
        Info_Player.item_snowboard = true;
        buyButton.interactable = false;
        switch(tipo){
            case 0:
                Info_Player.item_snowboard = true;
                Info_Player.coins = Info_Player.coins - 200;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
            case 1:
                Info_Player.item_snowfight = true;
                Info_Player.coins = Info_Player.coins - 200;
                buyButton.interactable = false;
                Info_Player.totalizador++;

            break;
            case 2:
                Info_Player.item_cooking = true;
                Info_Player.coins = Info_Player.coins - 300;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
            case 3:
                Info_Player.item_snowman = true;
                Info_Player.coins = Info_Player.coins - 200;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
        }
        moeda.attMoedas();
    }
    

    public void GambADDPOINTS(){
        Info_Player.score_snowboard = 2001;
        Debug.Log(Info_Player.item_snowboard);
        CheckScore();
    }

}