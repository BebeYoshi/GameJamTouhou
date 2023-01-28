using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;

    public bool hidden;

    public GameObject point_maker;
    public GameObject enemy_spawner;


    void Start()
    {
        health = 3;
    }

    public void TakeDamage()
    {
        hidden = gameObject.GetComponent<EnemyBehaviour>().hidden;
        if(hidden == false)
        {
            health--;
        }
        if(health == 0)
        {
            point_maker.GetComponent<ScorePoint>().Score();
            enemy_spawner.GetComponent<SpawnEnemy>().EnemyDeath();
            Destroy(gameObject);
        }
    }
}
