using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Cidade : MonoBehaviour
{

    public float moveSpeed = 3.8f;
    public bool isAllowed = true;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per fra
    void Start(){
        isAllowed = true;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }
    void FixedUpdate()
    {
        if(isAllowed){
            rb.velocity = movement * moveSpeed;
        }
    }
}
