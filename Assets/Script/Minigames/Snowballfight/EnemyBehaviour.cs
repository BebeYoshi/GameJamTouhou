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

    //How hard the game is right now
    public int internalDifficulty;
    //Current position difficulty
    public int difficulty;

    //If the enemy is hidden from attacks
    public bool hidden;

    //Get the player to deal damage;
    public GameObject player;
    public GameObject enemy_spawner;

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
        internalDifficulty = enemy_spawner.GetComponent<SpawnEnemy>().deaths;
        hidden = false;

        ChangeDifficulty();
        DecrementIntervals();
        StartCoroutine(DoAction());
    }

    IEnumerator DoAction()
    {
        int randomIndex;
        int randomAction = UnityEngine.Random.Range(0, 10);
        if (difficulty == 1)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            if(randomAction > 8)
            {
                if(randomAction == 10)
                {
                    yield return new WaitForSeconds(shootDowntime);
                    StartCoroutine(Shoot());
                    yield break;
                }
                StartCoroutine(Hide());
                yield break;
            }
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        //If normal pattern is choosen
        if (difficulty == 2)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        //If hard pattern is choosen
        if (difficulty == 3)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        StartCoroutine(DoAction());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootDowntime);
    }

    void ChangeDifficulty()
    {
        difficulty = 1;
        if (internalDifficulty >= 3)
        {
            difficulty = 2;
        }
        if (internalDifficulty >= 10)
        {
            difficulty = 3;
        }
    }

    void DecrementIntervals()
    {
        if (internalDifficulty >= 19)
        {
            actionInterval = 0.4f;
            shootDowntime = 0.7f;
        }
        actionInterval /= Mathf.Pow(1.05f, internalDifficulty);
        shootDowntime /= Mathf.Pow(1.02f, internalDifficulty);
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
