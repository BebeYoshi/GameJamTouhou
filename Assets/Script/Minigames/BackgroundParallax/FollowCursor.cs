using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{

    private void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.y = 0f;
        mouseWorldPosition.x /= 10f;
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }
}