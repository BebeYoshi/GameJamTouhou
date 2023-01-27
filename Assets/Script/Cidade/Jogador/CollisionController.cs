using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController : MonoBehaviour
{
    public bool abriuLoja;
    public PlayerMovement_Cidade mov;
    
    void Start(){
        abriuLoja = false;
    }

void OnCollisionStay2D(Collision2D col)
    {
        // Animação de exclamação
       if(col.gameObject.name == "Lojinha" && Input.GetKeyDown(KeyCode.E) && !abriuLoja){
            // Levar pra outra cena
            abriuLoja = true;
            mov.isAllowed = false;
            SceneManager.LoadScene("Loja", LoadSceneMode.Additive);
       }
    }
}
