using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    //Possible locations the Enemy can move to
    List<Vector2> positionList = new List<Vector2>();
    public Vector2 possibleSpot_variant1 = new Vector2(3.5f, 0.2f);
    public Vector2 possibleSpot_variant2 = new Vector2(-0.22f, -0.63f);
    public Vector2 possibleSpot_variant3 = new Vector2(-4.73f, 0.12f);
    public Vector2 possibleSpot_variant4 = new Vector2(-10.78f, 0.58f);
    public Vector2 possibleSpot_variant5 = new Vector2(-7.93f, -1.23f);
    public Vector2 possibleSpot_variant6 = new Vector2(8.86f, -1.41f);
    public Vector2 possibleSpot_variant7 = new Vector2(10.78f, -1.73f);
    public Vector2 possibleSpot_variant8 = new Vector2(1.99f, -1.77f);
    public Vector2 possibleSpot_variant9 = new Vector2(-2.81f, -1.91f);
    public Vector2 possibleSpot_variant10 = new Vector2(-6.94f, -1.7f);
    public Vector2 possibleSpot_variant11 = new Vector2(12.23f, 3.96f);
    public Vector2 possibleSpot_variant12 = new Vector2(-12f, 3.96f);

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
    //So Enemy can't attack right after hiding or starting the game
    public bool noAttack;

    //Get the player to deal damage;
    public GameObject player;
    public GameObject snowballEnemy;

    void Start()
    {
        //Insert the possible locations inside the List
        positionList.Add(possibleSpot_variant1);
        positionList.Add(possibleSpot_variant2);
        positionList.Add(possibleSpot_variant3);
        positionList.Add(possibleSpot_variant4);
        positionList.Add(possibleSpot_variant5);
        positionList.Add(possibleSpot_variant6);
        positionList.Add(possibleSpot_variant7);
        positionList.Add(possibleSpot_variant8);
        positionList.Add(possibleSpot_variant9);
        positionList.Add(possibleSpot_variant10);
        positionList.Add(possibleSpot_variant11);
        positionList.Add(possibleSpot_variant12);
        actionInterval = 1.5f;
        shootDowntime = 1.5f;
        internalDifficulty = gameObject.GetComponent<EnemyHealth>().deaths;
        hidden = false;
        noAttack = true;

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
            randomIndex = UnityEngine.Random.Range(0, 5);
            if (randomAction == 9 && !noAttack)
            {
                Instantiate(snowballEnemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(shootDowntime);
                StartCoroutine(Shoot());
                yield break;
            }
            if (randomAction >= 8)
            {
                StartCoroutine(Hide());
                yield break;
            }
            noAttack = false;
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        //If in normal mode(less than 10 deaths more than 3)
        if (difficulty == 2)
        {
            randomIndex = UnityEngine.Random.Range(0, 8);
            if (randomAction >= 8 && !noAttack)
            {
                Instantiate(snowballEnemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
                StartCoroutine(Shoot());
                yield break;
            }
            if (randomAction >= 6)
            {
                StartCoroutine(Hide());
                yield break;
            }
            noAttack = false;
            transform.position = positionList[randomIndex];
            yield return new WaitForSeconds(actionInterval);
        }
        //If in hard mode(more than 10 deaths)
        if (difficulty == 3)
        {
            randomIndex = UnityEngine.Random.Range(0, 12);
            if (randomAction >= 7 && !noAttack)
            {
                Instantiate(snowballEnemy, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                yield return new WaitForSeconds(shootDowntime);
                StartCoroutine(Shoot());
                yield break;
            }
            if (randomAction >= 5)
            {
                StartCoroutine(Hide());
                yield break;
            }
            noAttack = false;
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
        internalDifficulty = gameObject.GetComponent<EnemyHealth>().deaths;
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
        actionInterval = 1.5f/Mathf.Pow(1.05f, internalDifficulty);
        shootDowntime = 1.5f/Mathf.Pow(1.02f, internalDifficulty);
    }

    //Enemy hides from attacks
    IEnumerator Hide()
    {
        hidden = true;
        transform.position = new Vector2(-1.5f, -2.5f);
        yield return new WaitForSeconds(2f);
        hidden = false;
        noAttack = true;
        StartCoroutine(DoAction());
    }
}
