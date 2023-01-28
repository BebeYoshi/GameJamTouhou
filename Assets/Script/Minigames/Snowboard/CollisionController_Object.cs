using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionController_Object : MonoBehaviour
{

    public bool jumpable = false;
    public bool crounchable = false;

    void OnTriggerEnter2D(Collider2D col)
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
            if(gameObject.transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        if (col.gameObject.name == "Score_marker")
        {
            col.gameObject.GetComponent<Point_count>().CountPoint();
            Destroy(gameObject);
        }
    }
}
