using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{
   public TMP_Text textoMoedas;
   public int moedas;
    public TMP_Text textoItem;
    public GameObject estrelinha;

    // Update is called once per frame

    void Start(){
        Info_Player.coins = 50000;
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
        textoItem.SetText("Buy the necessary items to end the winter!");
    }
    
    public void attMoedas(){
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
    }

    public void checarItens(){
        if(Info_Player.totalizador == 4){
            textoItem.SetText("Offer the items at the tree!");
            estrelinha.SetActive(true);
            Info_Player.finalizado = true;
        }
        
    }

    public void addMoeda (){
        Info_Player.coins = moedas+1;
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
    }


}
