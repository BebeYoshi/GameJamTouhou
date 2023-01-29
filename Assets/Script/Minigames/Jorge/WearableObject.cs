using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearableObject : DragObject
{
    public GameObject wearPrefab;
    public GameObject wearObject;
    public GameObject Jorge;
    public bool weared;

    // Start is called before the first frame update
    new void Start()
    {
        Jorge = GameObject.Find("Jorge");
        base.Start();
        weared = false;
        wearObject = Instantiate(wearPrefab, wearPrefab.transform.position, wearPrefab.transform.rotation);
        wearObject.SetActive(false);
    }

    // Update is called once per frame
    new void Update()
    {
        var col = gameObject.GetComponent<Collider2D>();
        var colJorge = Jorge.GetComponent<Collider2D>();
        if (!dragging && col.IsTouching(colJorge))
        {
            weared = true;
            gameObject.SetActive(false);
        }
        base.Update();
    }
}
