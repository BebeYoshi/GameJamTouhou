using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Livro : MonoBehaviour
{
    public Minigames_UI uiMinigames;
    
    void Start(){
    }

void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && !uiMinigames.minigamesPanel.activeSelf){
        Debug.Log("abriu");
            uiMinigames.ToggleCanvas();
       }
    }
  
}
