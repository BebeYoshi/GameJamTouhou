using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chawan : MonoBehaviour
{
    public Texture2D NormalTexture;
    public Texture2D GrabTexture;
    public GameObject ingrediente;
    // Start is called before the first frame update
    void Start()
    {
        NormalTexture = Resources.Load("cursor2", typeof(Texture2D)) as Texture2D;
        GrabTexture = Resources.Load("cursor1", typeof(Texture2D)) as Texture2D;
        Cursor.SetCursor(NormalTexture, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Cursor.SetCursor(GrabTexture, Vector2.zero, CursorMode.Auto);
        ingrediente.GetComponent<CookingObject>().offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ingrediente.GetComponent<CookingObject>().dragging = true;
        ingrediente.SetActive(true);
    }

    private void OnMouseUp()
    {
        Cursor.SetCursor(NormalTexture, Vector2.zero, CursorMode.Auto);
        ingrediente.GetComponent<CookingObject>().dragging = false;
        ingrediente.SetActive(false);
    }
}
