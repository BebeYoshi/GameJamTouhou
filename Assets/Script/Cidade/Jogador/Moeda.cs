using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{
   public TMP_Text textoMoedas;
   public int moedas;
    public TMP_Text textoItem;

    // Update is called once per frame

    void Start(){
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
        textoItem.SetText("Item não comprado");
    }
    
    void Update()
    {
        if(Info_Player.item_snowboard){
            textoItem.SetText("Item comprado");
        }

    }

    public void addMoeda (){
        Info_Player.coins = moedas+1;
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
    }


}
