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
        }
        if (Input.GetButtonUp("Jump"))
        {
            idle = true;
            jump = false;
        }
        if (Input.GetButton("Crounch") && jump == false)
        {
            idle = false;
            crounch = true;
        }
        if (Input.GetButtonUp("Crounch"))
        {
            idle = true;
            crounch = false;
        }
    }

}
