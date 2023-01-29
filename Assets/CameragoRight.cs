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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * movingSpeed;
    }
}
