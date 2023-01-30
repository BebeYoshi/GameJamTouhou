using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingObject : MonoBehaviour
{
    public bool cooked;
    public bool dragging = false;
    public Vector3 offset;
    public Vector3 initialPosition;
    public Vector3 startMouse;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        cooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
