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
        this.gameObject.GetComponent<SoundEffectPlayer>().Play2();
        StartCoroutine(PlaySound());
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

    IEnumerator PlaySound()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        this.gameObject.GetComponent<SoundEffectPlayer>().Play3();
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}