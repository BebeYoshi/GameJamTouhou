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
        action = Input.GetAxisRaw("Vertical");
        if(action == 1f)
        {
            StartCoroutine(Jump());
        }
        if (action == -1f)
        {
            StartCoroutine(Crounch());
        }
    }

    IEnumerator Jump()
    {
        if(idle == true)
        {
            idle = false;
            jump = true;
            yield return new WaitForSeconds(1);
            idle = true;
            jump = false;
        }
    }

    IEnumerator Crounch()
    {
        if (idle == true)
        {
            idle = false;
            crounch = true;
            yield return new WaitForSeconds(1);
            idle = true;
            crounch = false;
        }
    }
}
