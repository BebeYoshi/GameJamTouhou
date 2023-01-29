using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool hidden;
    public bool onCooldown;

    public float shootCooldown;

    public Sprite attackPlayer;
    public Sprite idlePlayer;
    public Sprite hiddenPlayer;

    public Vector2 hiddenPosition;
    public Vector2 originalPosition;

    public GameObject crosshair;
    public GameObject snowballPrefab;

    void Start()
    {
        hidden = false;
        shootCooldown = 0.2f;
        originalPosition = new Vector2(transform.position.x, transform.position.y);
        hiddenPosition = new Vector2(transform.position.x, transform.position.y-0.65f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Crounch"))
        {
            hidden = true;
            transform.position = hiddenPosition;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hiddenPlayer;
        }
        if (Input.GetButtonUp("Crounch"))
        {
            hidden = false;
            transform.position = originalPosition;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idlePlayer;
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }

    }


    IEnumerator Shoot()
    {
        if(hidden == false && !onCooldown)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = attackPlayer;
            Instantiate(snowballPrefab, new Vector2(crosshair.transform.position.x, crosshair.transform.position.y), Quaternion.identity);
            onCooldown = true;
            StartCoroutine(SnowballSound());
            yield return new WaitForSeconds(shootCooldown);
            onCooldown = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = idlePlayer;
        }
    }

    IEnumerator SnowballSound()
    {
        yield return new WaitForSeconds(0.4f);
        this.gameObject.GetComponent<SoundEffectPlayer>().Play1();
    }
}
