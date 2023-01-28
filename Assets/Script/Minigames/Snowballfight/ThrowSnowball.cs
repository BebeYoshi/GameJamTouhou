using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{

    public bool isColliderEnabled;

    public Vector2 startPosition;
    public Vector3 targetPosition;

    public float time;
    public float timeToReachTarget;


    void Start()
    {
        isColliderEnabled = false;
        targetPosition = transform.position;
        startPosition = new Vector2(-3.52f, -2.25f);
        transform.position = startPosition;
        timeToReachTarget = 0.4f;
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

    void OnTriggerStay2D(Collider2D col)
    {
        if(isColliderEnabled == true && col.gameObject.name == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }

    IEnumerator Damage()
    {
        isColliderEnabled = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
