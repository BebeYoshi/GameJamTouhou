using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearTimer : MonoBehaviour
{
    Image TimerBar;
    public float maxTime;
    float timeLeft;
    public GameObject TimesUp;
    public bool ended;

    // Start is called before the first frame update
    void Start()
    {
        TimesUp.SetActive(false);
        TimerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    public void NewRound(float maxTime)
    {
        TimesUp.SetActive(false);
        this.maxTime = maxTime;
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            TimerBar.fillAmount = timeLeft / maxTime;
        } else
        {
            TimesUp.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
