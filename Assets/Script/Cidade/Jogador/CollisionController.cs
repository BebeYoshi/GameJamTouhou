using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController : MonoBehaviour
{
    public bool abriuLoja;
    public PlayerMovement_Cidade mov;
    public Minigames_UI uiMinigames;
    
    void Start(){
        abriuLoja = false;
    }

void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Lojinha" && Input.GetKey(KeyCode.E) && !uiMinigames.minigamesPanel.activeSelf){
        Debug.Log("abriu");
            uiMinigames.ToggleCanvas();
       }
    }
  
}
