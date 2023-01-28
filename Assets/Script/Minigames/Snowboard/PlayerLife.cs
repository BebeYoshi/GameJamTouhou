using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{

    public TMP_Text textoLife;
    public int life;

    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        life = 3;
        textoLife.SetText("Life: " + life.ToString());
        movement.x = -7;
        movement.y = 3;
    }

    public void LoseLife()
    {
        life--;
        textoLife.SetText("Life: " + life.ToString());
        if (life == 0)
        {
            rb.position = movement;
            rb.gravityScale = 50;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Score_marker")
        {
            col.gameObject.GetComponent<Point_count>().FinaldeJogo();
            Destroy(gameObject);
        }
    }
}