using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class    CookingController : MonoBehaviour
{
    public List<GameObject> ingredients;
    public List<int> cookeds;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        cookeds = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ingredients.Count(); i++)
        {
            if (ingredients[i].GetComponent<CookingObject>().cooked)
            {
                Debug.Log(i);
                cookeds.Add(i);
                ingredients[i].GetComponent<CookingObject>().cooked = false;
            }
        }
    }

    public void NewRound()
    {
        cookeds = new List<int>();
    }
}
