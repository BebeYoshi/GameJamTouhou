using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameragoRight : MonoBehaviour
{

    public float movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movingSpeed = 3f;
        StartCoroutine(TurnLeft());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
    }

    IEnumerator TurnLeft()
    {
        yield return new WaitForSeconds(1f);
        movingSpeed --;
        if(movingSpeed <= -3f)
        {
            StartCoroutine(TurnRight());
        }
        StartCoroutine(TurnLeft());
    }

    IEnumerator TurnRight()
    {
        yield return new WaitForSeconds(1f);
        movingSpeed ++ ;
        if (movingSpeed >= 3f)
        {
            StartCoroutine(TurnLeft());
        }
        StartCoroutine(TurnRight());
    }
}
