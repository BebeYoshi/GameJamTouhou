using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Cidade : MonoBehaviour
{

    public float moveSpeed = 3.8f;
    public bool isAllowed = true;


    public Rigidbody2D rb;
    public Sprite playerFrente;
    public Sprite playerCostas;

    Vector2 movement;

    // Update is called once per fra
    void Start(){
        isAllowed = true;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x <0){
            if(this.gameObject.GetComponent<SpriteRenderer>().sprite == playerFrente){
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else{
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if(movement.x >0){
           if(this.gameObject.GetComponent<SpriteRenderer>().sprite == playerFrente){
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else{
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        if(movement.y <0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerFrente;
        }
        if(movement.y >0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerCostas;
        }
        
    }
    void FixedUpdate()
    {
        if(isAllowed){
            rb.velocity = movement * moveSpeed;
        }
    }

}
