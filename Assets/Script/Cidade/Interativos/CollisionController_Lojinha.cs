using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Lojinha : MonoBehaviour
{
    
    void Start(){
    }

void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Player" && Input.GetKey(KeyCode.E) && Info_Player.finalizado == true){
            SceneManager.LoadScene("Ending");
       }
    }
  
}
