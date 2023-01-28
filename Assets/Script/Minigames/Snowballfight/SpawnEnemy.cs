using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public int deaths;

    public GameObject enemy;

    void Start()
    {
        deaths = 1;
        Instantiate(enemy);
    }

    // Update is called once per frame
    public void EnemyDeath()
    {
        deaths++;
        Instantiate(enemy);
    }
}
