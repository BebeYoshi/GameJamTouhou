using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool dragging = false;
    private Vector3 offset;
    public Vector3 initialPosition;

    // Start is called before the first frame update
    public void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        } else
        {
            transform.position = initialPosition;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
