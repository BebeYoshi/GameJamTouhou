using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SopaGameController : MonoBehaviour
{
    public CookingController cookingController;
    private List<int> order;
    private bool GameOver;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        order = new List<int>();
        NewRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            var cookeds = cookingController.cookeds;
            var success = true;
            for (int i = 0; i < cookeds.Count; i++)
            {
                if (cookeds[i] != order[i])
                {
                    success = false;
                    break;
                }
            }
            if (success && (cookeds.Count == order.Count))
            {
                //Score
                NewRound();
            } else if (!success)
            {
                GameOver = true;
            }
        }
    }

    void NewRound()
    {
        order.Add(UnityEngine.Random.Range(0, 8));
        cookingController.NewRound();
    }
}
