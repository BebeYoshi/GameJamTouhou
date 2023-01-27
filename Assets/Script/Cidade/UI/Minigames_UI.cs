using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigames_UI : MonoBehaviour
{
    public GameObject minigamesPanel;


    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleCanvas(){
        if(!minigamesPanel.activeSelf){
            minigamesPanel.SetActive(true);
        }else{
            minigamesPanel.SetActive(false);
        }
    }
}
