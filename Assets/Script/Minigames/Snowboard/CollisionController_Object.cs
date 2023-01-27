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
            col.gameObject.GetComponent<PlayerLife>().LoseLife();
        }
        if (col.gameObject.name == "Score_marker")
        {
            col.gameObject.GetComponent<Point_count>().score += 200;
            col.gameObject.GetComponent<Point_count>().textoScore = col.gameObject.GetComponent<Point_count>().score.ToString();
            Destroy(gameObject);
        }
    }
}
