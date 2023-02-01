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
    public GameObject missao;


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
            missao.SetActive(false);
            CheckScore();
            Debug.Log(Info_Player.totalizador);
        }else{
            npcPanel.SetActive(false);
            missao.SetActive(true);
            moeda.checarItens();
        }
    }

    public void CheckScore(){
        switch(tipo){
            case 0:
                if(Info_Player.score_snowboard >= 2000 && Info_Player.item_snowboard == false && Info_Player.coins >= 40){
                    textoLoja.SetText("In stock. I made this myself!");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_snowboard < 2000){
                    textoLoja.SetText("You need a bit more snowboard expertise, but please be careful Reimu. (At least 2000 highscore)");

                }
                else if(Info_Player.item_snowboard == true){
                    textoLoja.SetText("I hope you enjoyed the mochi Reimu!");
                }
                else {
                    textoLoja.SetText("I'm sure gathering more coins will not be a problem for you!");
                    buyButton.interactable = false;
                }
            break;
            case 1:
              if(Info_Player.score_snowballfight >= 2000 && Info_Player.item_snowfight == false && Info_Player.coins >= 70){
                    textoLoja.SetText("You should be thanking me for this cheap price.");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_snowballfight  < 2000){
                    textoLoja.SetText("Go and steal all Cirno's points! (At least 2000 score)");

                }
                else if(Info_Player.item_snowfight == true && Info_Player.coins >= 70){
                    textoLoja.SetText("I'm sold out. But sure, go ahead and give me more money.");
                    buyButton.interactable = true;
                }
                else if(Info_Player.item_snowfight == true && Info_Player.coins < 70){
                    textoLoja.SetText("Even though I can only read a youkai, your aura tells me you are broke.");
                }
                else {
                    textoLoja.SetText("Huh? The standard price is 40? These people don't know how to make money");
                    buyButton.interactable = false;
                }


            break;
            case 2:
            if( Info_Player.item_cooking == false && Info_Player.coins >= 40){
                    textoLoja.SetText("Moon Juice! This is 'jumping' off the shelves! (It's actually Spring Essence)");
                    buyButton.interactable = true;
                }
                else if(Info_Player.item_cooking == true){
                    textoLoja.SetText("I'm sorry, I'm not allowed to sell you more.");
                }
                else {
                    textoLoja.SetText("I'm afraid this isn't enough money for master.");
                    buyButton.interactable = false;
                }


            break;
            case 3:
            if(Info_Player.score_jorge >= 2000 && Info_Player.item_snowman == false && Info_Player.coins >= 40){
                    textoLoja.SetText("So you see.. This item is a really special antique, it was used.. (Better to ignore the lengthy explanation)");
                    buyButton.interactable = true;
                }
                else if(Info_Player.score_jorge  < 2000){
                    textoLoja.SetText("Jorge should be in need of a new look. (At least 2000 score in snowman dress up)");

                }
                else if(Info_Player.item_snowman == true){
                    textoLoja.SetText("These kind of items are rare, Marisa. I can't sell you more than one. ");
                }
                else {
                    textoLoja.SetText("You know Marisa, this is a highly valued item.");
                    buyButton.interactable = false;
                }
            break;
        }

    }

    public void buyItem(){
        buyButton.interactable = false;
        switch(tipo){
            case 0:
                Info_Player.item_snowboard = true;
                Info_Player.coins = Info_Player.coins - 40;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
            case 1:
                if(Info_Player.item_snowfight == false){
                    Info_Player.totalizador++;
                }
                Info_Player.item_snowfight = true;
                Info_Player.coins = Info_Player.coins - 70;
                buyButton.interactable = false;

            break;
            case 2:
                Info_Player.item_cooking = true;
                Info_Player.coins = Info_Player.coins - 40;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
            case 3:
                Info_Player.item_snowman = true;
                Info_Player.coins = Info_Player.coins - 40;
                buyButton.interactable = false;
                Info_Player.totalizador++;
            break;
        }
        moeda.attMoedas();
        CheckScore();
    }
    

    public void GambADDPOINTS(){
        Info_Player.score_snowboard = 2001;
        Debug.Log(Info_Player.item_snowboard);
        CheckScore();
    }

}