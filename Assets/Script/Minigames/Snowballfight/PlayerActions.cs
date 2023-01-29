using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool hidden;

    public GameObject crosshair;
    public GameObject snowballPrefab;

    void Start()
    {
        hidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Crounch"))
        {
            hidden = true;
        }
        if (Input.GetButtonUp("Crounch"))
        {
            hidden = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }


    void Shoot()
    {
        if(hidden == false)
        {
            Instantiate(snowballPrefab, new Vector2(crosshair.transform.position.x, crosshair.transform.position.y), Quaternion.identity);
        }
    }
}
