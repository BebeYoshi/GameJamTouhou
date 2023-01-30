using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LinearTimer : MonoBehaviour
{
    Image TimerBar;
    public float maxTime;
    float timeLeft;
    public GameObject TimesUp;
    public TMP_Text TimeUp;
    public bool ended;
    private bool stopped;

    // Start is called before the first frame update
    void Start()
    {
        TimesUp.SetActive(false);
        TimerBar = GetComponent<Image>();
        timeLeft = maxTime;
        Unstop();
    }

    public void NewRound(float maxTime)
    {
        TimesUp.SetActive(false);
        this.maxTime = maxTime;
        timeLeft = maxTime;
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Unstop()
    {
        stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            if (!stopped) timeLeft -= Time.deltaTime;
            TimerBar.fillAmount = timeLeft / maxTime;
        } else
        {
            StartCoroutine(disableTimeUp());
            //Time.timeScale = 0;
            ended = true;
        }
    }
    IEnumerator disableTimeUp()
    {
        TimesUp.SetActive(true);
        yield return new WaitForSeconds(3f);
        TimeUp.SetText("");
    }
}
