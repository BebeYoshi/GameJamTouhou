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
        this.gameObject.GetComponent<SoundEffectPlayer>().src = GameObject.Find("Audio Source").GetComponent<AudioSource>();
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
        this.gameObject.GetComponent<SoundEffectPlayer>().Play1();
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        this.gameObject.GetComponent<SoundEffectPlayer>().Play2();
        dragging = false;
    }
}
