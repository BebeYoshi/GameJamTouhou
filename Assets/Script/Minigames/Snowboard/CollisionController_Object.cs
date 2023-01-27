using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Object : MonoBehaviour
{

    public bool jumpable = false;
    public bool crounchable = false;

    void OnCollisionEnter2D(Collision2D col)
    {
       if(col.gameObject.name == "Player")
        {
            if(jumpable == true && col.gameObject.GetComponent<JumpCrounch>().jump == true )
            {
                return;
            }
            if (crounchable == true && col.gameObject.GetComponent<JumpCrounch>().crounch == true)
            {
                return;
            }
            Debug.Log("morreu");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.name == "Score_marker")
        {
               
        }
    }
}
