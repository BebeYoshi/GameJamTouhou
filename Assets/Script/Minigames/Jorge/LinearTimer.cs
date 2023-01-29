using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearTimer : MonoBehaviour
{
    Image TimerBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject TimesUp;

    // Start is called before the first frame update
    void Start()
    {
        TimesUp.SetActive(false);
        TimerBar = GetComponent<Image>();
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
