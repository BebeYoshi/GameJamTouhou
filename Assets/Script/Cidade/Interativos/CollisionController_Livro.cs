using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Livro : MonoBehaviour
{
    public Minigames_UI uiMinigames;
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

       if(col.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && !uiMinigames.minigamesPanel.activeSelf){
        Debug.Log("abriu");
            uiMinigames.ToggleCanvas();
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
