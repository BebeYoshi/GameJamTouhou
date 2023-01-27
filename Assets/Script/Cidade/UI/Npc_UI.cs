using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_UI : MonoBehaviour
{
    public GameObject npcPanel;


    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleCanvas(){
        if(!npcPanel.activeSelf){
            npcPanel.SetActive(true);
        }else{
            npcPanel.SetActive(false);
        }
    }
}
