using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moeda : MonoBehaviour
{
   public TMP_Text textoMoedas;
   public int moedas;

    // Update is called once per frame

    void Start(){
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
    }
    
    void Update()
    {

    }

    public void addMoeda (){
        Info_Player.coins = moedas+1;
        moedas = Info_Player.coins;
        textoMoedas.SetText(moedas.ToString());
    }
}
