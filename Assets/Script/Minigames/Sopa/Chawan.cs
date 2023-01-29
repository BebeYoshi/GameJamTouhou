using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chawan : MonoBehaviour
{
    public GameObject ingrediente;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
       ingrediente.GetComponent<CookingObject>().offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
       ingrediente.GetComponent<CookingObject>().dragging = true;
       ingrediente.SetActive(true);
    }

    private void OnMouseUp()
    {
        ingrediente.GetComponent<CookingObject>().dragging = false;
        ingrediente.SetActive(false);
    }
}
