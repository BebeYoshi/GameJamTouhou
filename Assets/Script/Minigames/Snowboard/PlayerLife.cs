using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public string textoLife;
    public int life;

    public Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        life = 1;
        textoLife = life.ToString();
        movement.x = -7;
        movement.y = 3;
    }

    public void LoseLife()
    {
        life--;
        textoLife = life.ToString();
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