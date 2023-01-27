using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCrounch : MonoBehaviour
{

    public float duration = 1;

    public bool idle = true;
    public bool jump = false;
    public bool crounch = false;

    public float action;

    // Update is called once per frame
    void Update()
    {
        action = Input.GetAxisRaw("Vertical");
        if(action == 1)
        {
            Jump();
        }
        if (action == -1)
        {
            Crounch();
        }
    }

    IEnumerator Jump()
    {
        if(idle == true)
        {
            idle = false;
            jump = true;
            yield return new WaitForSeconds(duration);
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
            yield return new WaitForSeconds(duration);
            idle = true;
            crounch = false;
        }
    }
}
