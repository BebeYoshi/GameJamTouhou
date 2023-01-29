using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingObject : MonoBehaviour
{
    public GameObject Sopa;
    public bool weared;
    public bool dragging = false;
    private Vector3 offset;
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
            //gameObject.SetActive(false);
        }
        if (dragging)
        {
            transform.position = (Input.mousePosition) + initialPosition - startMouse;
        } else
        {
            transform.position = initialPosition;
        }
    }

    public void OnMouseDown()
    {
        startMouse = Input.mousePosition;
        //transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        Debug.Log("Ingrediente");
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
