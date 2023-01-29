using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCrounch : MonoBehaviour
{

    public float duration = 1f;

    public bool idle;
    public bool jump;
    public bool crounch;

    public float action;

    public Sprite idlePlayer;
    public Sprite jumpingPlayer;
    public Sprite crounchingPlayer;

    void Start()
    {
        idle = true;
        jump = false;
        crounch = false;
    }

    void Update()
    {
        if(Input.GetButton("Jump") && crounch == false)
        {
            idle = false;
            jump = true;
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = jumpingPlayer;
        }
        if (Input.GetButtonUp("Jump"))
        {
            idle = true;
            jump = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idlePlayer;
            this.gameObject.GetComponent<Animator>().enabled = true;
        }
        if (Input.GetButton("Crounch") && jump == false)
        {
            idle = false;
            crounch = true;
            this.gameObject.GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crounchingPlayer;
        }
        if (Input.GetButtonUp("Crounch"))
        {
            idle = true;
            crounch = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idlePlayer;
            this.gameObject.GetComponent<Animator>().enabled = true; ;
        }
    }

}
