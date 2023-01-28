using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool hidden;

    public float action;

    public GameObject crosshair;

    void Start()
    {
        hidden = false;
        action = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        if (action == -1f)
        {
            Hide();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Hide()
    {
        while (action == -1f)
        {
            hidden = true;
        }
        hidden = false;
    }


    void Shoot()
    {
        if(hidden = false)
        {

        }
    }
}
