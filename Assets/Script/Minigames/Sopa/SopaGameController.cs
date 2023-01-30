using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SopaGameController : MonoBehaviour
{
    public CookingController cookingController;
    public ScoreCooking ScoreSopa;
    private List<int> order;
    private bool GameOver;
    public TMP_Text NumAtual;
    public TMP_Text NumAnterior;
    public GameObject spoon;

    private string[] ingredientMapping = new string[]
    {
        "ONION",
        "TOFU",
        "SCALLION",
        "NOODLES",
        "DASHI",
        "MISO",
        "SALT",
        "MEAT"
    };
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        order = new List<int>();
        GameOver = false;
        spoon.GetComponent<Animator>().enabled = false;
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
                ScoreSopa.Score(order.Count*150);
                StartCoroutine(TurnSpoonAround());
                NewRound();
            } else if (!success)
            {
                GameOver = true;
                ScoreSopa.FinaldeJogo();
            }
        }
    }

    void NewRound()
    {
        order.Add(UnityEngine.Random.Range(0, 8));
        ShowOrder();
        cookingController.NewRound();
    }

    void ShowOrder()
    {
        int n = order.Count;
        NumAtual.SetText(n + "\n" + ingredientMapping[order[n-1]]);
        NumAnterior.SetText("");
        if (n > 1)
        {
            NumAnterior.SetText(n-1 + "\n" + ingredientMapping[order[n-2]]);
        }
    }

    IEnumerator TurnSpoonAround()
    {
        spoon.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1f);
        spoon.GetComponent<Animator>().enabled = false;
    }
}
