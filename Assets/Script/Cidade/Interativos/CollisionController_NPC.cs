using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_NPC : MonoBehaviour
{
    public Npc_UI uiNpc;
    public GameObject exclamacaoIMG;
    
    void Start(){
    }

void OnCollisionEnter2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player"  && !exclamacaoIMG.activeSelf){
            exclamacaoIMG.SetActive(true);
       }
    }


void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && !uiNpc.npcPanel.activeSelf){
        Debug.Log("abriu");
            uiNpc.ToggleCanvas();
       }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player"  && exclamacaoIMG.activeSelf){
            exclamacaoIMG.SetActive(false);
       }
    }
  
}
