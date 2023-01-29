using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowballEnemy : MonoBehaviour
{

    public Vector2 startPosition;
    public Vector3 targetPosition;

    public float time;
    public float timeToReachTarget;


    void Start()
    {
        targetPosition = new Vector2(-3.52f, -2.25f);
        startPosition = transform.position;
        timeToReachTarget = 0.7f;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime / timeToReachTarget;
        transform.position = Vector2.Lerp(startPosition, targetPosition, time);
        if(transform.position == targetPosition)
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
