using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public int deaths;

    public TMP_Text textHealth;

    public float immuneTime;

    public bool hidden;
    public bool immune;

    public GameObject point_maker;

    void Start()
    {
        health = 3;
        textHealth.SetText("Health: " + health.ToString());
        deaths = 1;
        immuneTime = 0.5f;
    }

    public void TakeDamage()
    {
        hidden = gameObject.GetComponent<EnemyBehaviour>().hidden;
        if (hidden == false && immune == false)
        {
            health--;
            textHealth.SetText("Health: " + health.ToString());
            this.gameObject.GetComponent<SoundEffectPlayer>().Play3();
            immune = true;
            StartCoroutine(Immune());
        }
        if (health <= 0)
        {
            point_maker.GetComponent<ScorePoint>().Score();
            deaths++;
            gameObject.GetComponent<EnemyBehaviour>().ChangeDifficulty();
            gameObject.GetComponent<EnemyBehaviour>().DecrementIntervals();
            health = 3;
            textHealth.SetText("Health: " + health.ToString());
        }
    }

    IEnumerator Immune()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(immuneTime);
        immune = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
