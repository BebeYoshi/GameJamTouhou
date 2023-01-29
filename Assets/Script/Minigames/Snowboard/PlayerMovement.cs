using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Sprite idlePlayer;
    public Sprite movingPlayer;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal") && this.gameObject.GetComponent<SpriteRenderer>().sprite == idlePlayer)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = movingPlayer;
            this.gameObject.GetComponent<Animator>().enabled = false;
        }
        if (Input.GetButtonUp("Horizontal") && this.gameObject.GetComponent<SpriteRenderer>().sprite == movingPlayer)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idlePlayer;
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
