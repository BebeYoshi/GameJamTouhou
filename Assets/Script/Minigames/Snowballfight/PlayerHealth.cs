using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public int health;

    public TMP_Text textHealth;

    public float immuneTime;

    public bool immune;
    public bool hidden;

    public GameObject point_marker;

    void Start()
    {
        health = 3;
        textHealth.SetText("Health: " + health.ToString());
        immuneTime = 1f;
    }

    // Update is called once per frame
    public void TakeDamage()
    {
        hidden = gameObject.GetComponent<PlayerActions>().hidden;
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
            point_marker.GetComponent<ScorePoint>().FinaldeJogo();
            Destroy(gameObject);
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
