using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    //Possible locations the Enemy can move to
    List<Vector2> positionList = new List<Vector2>();
    public Vector2 possibleSpot_variant1 = new Vector2(3.5f, 0.2f);
    public Vector2 possibleSpot_variant2 = new Vector2(-0.22f, -0.63f);
    //public Vector2 possibleSpot_variant3 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant4 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant5 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant6 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant7 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant8 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant9 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant10 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant11 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant12 = new Vector2(-17f, -0.5f);
    //public Vector2 possibleSpot_variant13 = new Vector2(-17f, -0.5f);

    //How long the enemy takes to do an action in seconds
    public float actionInterval;
    //How long the enemy is unable to do an action after shooting in seconds
    public float shootDowntime;
    //How long it takes for difficulty to raise
    public float difficultyInterval;

    //Current difficulty
    public int difficulty;

    //If the enemy is hidden from attacks
    public bool hidden;

    void Start()
    {
        //Insert the possible locations inside the List
        positionList.Add(possibleSpot_variant1);
        positionList.Add(possibleSpot_variant2);
        //positionList.Add(possibleSpot_variant3);
        //positionList.Add(possibleSpot_variant4);
        //positionList.Add(possibleSpot_variant5);
        //positionList.Add(possibleSpot_variant6);
        //positionList.Add(possibleSpot_variant7);
        //positionList.Add(possibleSpot_variant8);
        //positionList.Add(possibleSpot_variant9);
        //positionList.Add(possibleSpot_variant10);
        //positionList.Add(possibleSpot_variant11);
        //positionList.Add(possibleSpot_variant12);
        //positionList.Add(possibleSpot_variant13);
        actionInterval = 1f;
        shootDowntime = 1f;
        difficultyInterval = 15f;
        difficulty = 1;
        hidden = false;

        StartCoroutine(DoAction());
        StartCoroutine(ChangeDifficulty());
        StartCoroutine(DecrementIntervals());
    }

    IEnumerator DoAction()
    {
        yield return new WaitForSeconds(actionInterval);
        int randomIndex;
        int randomAction = UnityEngine.Random.Range(0, 10);
        if (difficulty == 1)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            if(randomAction > 8)
            {
                if(randomAction == 10)
                {

                    StartCoroutine(DoAction());
                    yield break;
                }
                StartCoroutine(Hide());
                yield break;
            }
            transform.position = positionList[randomIndex];
        }
        //If normal pattern is choosen
        if (difficulty == 2)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
        }
        //If hard pattern is choosen
        if (difficulty == 3)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
        }
        StartCoroutine(DoAction());
    }

    IEnumerator ChangeDifficulty()
    {
        if (difficulty != 3)
        {
            yield return new WaitForSeconds(difficultyInterval);
            difficulty++;
            difficultyInterval *= 2;
            StartCoroutine(ChangeDifficulty());
        }
    }

    IEnumerator DecrementIntervals()
    {
        yield return new WaitForSeconds(actionInterval * 5);
        actionInterval /= 1.2f;
        shootDowntime /= 1.05f;
        if (actionInterval > 0.4f)
        {
            StartCoroutine(DecrementIntervals());
        }
    }

    IEnumerator Hide()
    {
        hidden = true;
        transform.position = new Vector2(-1.5f, -2.5f);
        yield return new WaitForSeconds(3f);
        hidden = false;
        StartCoroutine(DoAction());
    }
}
