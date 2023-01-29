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
        internalDifficulty = gameObject.GetComponent<EnemyHealth>().deaths;
        hidden = false;

        ChangeDifficulty();
        DecrementIntervals();
        StartCoroutine(DoAction());
    }

    //Lets the enemy choose their actions based on the difficulty
    public IEnumerator DoAction()
    {
        //Number used for random position
        int randomIndex;
        //Number used to determinate if the Enemy is going to change position, hide or shoot
        int randomAction = UnityEngine.Random.Range(0, 10);
        //If in easy mode (less than 3 deaths)
        if (difficulty == 1)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            if(randomAction >= 8)
            {
                if(randomAction == 9)
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
        //If in normal mode(less than 10 deaths more than 3)
        if (difficulty == 2)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        //If in hard mode(more than 10 deaths)
        if (difficulty == 3)
        {
            randomIndex = UnityEngine.Random.Range(0, 2);
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        StartCoroutine(DoAction());
    }

    //Shoot the player
    IEnumerator Shoot()
    {
        player.GetComponent<PlayerHealth>().TakeDamage();
        yield return new WaitForSeconds(shootDowntime);
        StartCoroutine(DoAction());
    }

    //Makes Enemy able to use more positions based on the number of times Enemy died
    public void ChangeDifficulty()
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

    //Makes the Enemy faster based on the number of times Enemy died
    public void DecrementIntervals()
    {
        if (internalDifficulty >= 19)
        {
            actionInterval = 0.4f;
            shootDowntime = 0.7f;
        }
        actionInterval /= Mathf.Pow(1.05f, internalDifficulty);
        shootDowntime /= Mathf.Pow(1.02f, internalDifficulty);
    }

    //Enemy hides from attacks
    IEnumerator Hide()
    {
        hidden = true;
        transform.position = new Vector2(-1.5f, -2.5f);
        yield return new WaitForSeconds(3f);
        hidden = false;
        StartCoroutine(DoAction());
    }
}
