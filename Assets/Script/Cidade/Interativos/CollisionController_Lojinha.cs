using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Lojinha : MonoBehaviour
{
    public Npc_UI npc;
    
    void Start(){
    }

void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && !npc.npcPanel.activeSelf){
        Debug.Log("abriu");
            npc.ToggleCanvas();
       }
    }
  
}
