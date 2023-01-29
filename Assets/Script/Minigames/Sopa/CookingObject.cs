using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingObject : MonoBehaviour
{
    public GameObject Sopa;
    public bool weared;
    public bool dragging = false;
    public Vector3 offset;
    public Vector3 initialPosition;
    public Vector3 startMouse;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        weared = false;
    }

    // Update is called once per frame
    void Update()
    {
        var col = gameObject.GetComponent<Collider2D>();
        var colSopa = Sopa.GetComponent<Collider2D>();
        if (!dragging && col.IsTouching(colSopa))
        {
            weared = true;
        }
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
