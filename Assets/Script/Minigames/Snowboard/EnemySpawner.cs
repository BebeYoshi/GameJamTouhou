using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Easy variants, single rocks
    List<GameObject> easyList = new List<GameObject>();
    public GameObject rockPrefab_variant1;
    public GameObject rockPrefab_variant2;
    public GameObject rockPrefab_variant3;

    //Normal variant, two rocks or big obstacle
    List<GameObject> normalList = new List<GameObject>();
    public GameObject trunkPrefab_variant1;
    public GameObject trunkPrefab_variant2;
    public GameObject blockagePrefab_variant1;
    public GameObject blockagePrefab_variant2;
    public GameObject rockPrefab_multiple_variant1;
    public GameObject rockPrefab_multiple_variant2;
    public GameObject rockPrefab_multiple_variant3;

    //Hard variant, a rock and a big obstacle
    List<GameObject> hardList = new List<GameObject>();
    public GameObject trunkPrefab_multiple_variant1;
    public GameObject trunkPrefab_multiple_variant2;
    public GameObject blockagePrefab_multiple_variant1;
    public GameObject blockagePrefab_multiple_variant2;

    //Spawn Timer for obstacle
    public float spawnerInterval;

    //Timer to change difficulty
    public float difficultyInterval;

    //Current difficulty maximum
    public int difficulty;


    // Start is called before the first frame update
    void Start()
    {
        //List of Easy enemies
        easyList.Add(rockPrefab_variant1);
        easyList.Add(rockPrefab_variant2);
        easyList.Add(rockPrefab_variant3);
        //List of Normal enemies
        normalList.Add(trunkPrefab_variant1);
        normalList.Add(trunkPrefab_variant2);
        normalList.Add(blockagePrefab_variant1);
        normalList.Add(blockagePrefab_variant2);
        normalList.Add(rockPrefab_multiple_variant1);
        normalList.Add(rockPrefab_multiple_variant2);
        normalList.Add(rockPrefab_multiple_variant3);
        //List of Hard enemies
        hardList.Add(trunkPrefab_multiple_variant1);
        hardList.Add(trunkPrefab_multiple_variant2);
        hardList.Add(blockagePrefab_multiple_variant1);
        hardList.Add(blockagePrefab_multiple_variant2);
        spawnerInterval = 3f;
        difficultyInterval = 15f;
        difficulty = 1;

        StartCoroutine(SpawnEnemies());
        StartCoroutine(ChangeDifficulty());
        StartCoroutine(DecrementInterval());
    }

    //Spawn enemies randomly based on the difficulty max
    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnerInterval);
        //Choose randomly one of the prefabs in the List based on the difficulty
        int randomIndex;
        //Randomly choose pattern based on difficulty
        int randomDifficulty = UnityEngine.Random.Range(1, difficulty+1);
        //If easy pattern is choosen
        if(randomDifficulty == 1)
        {
            randomIndex = UnityEngine.Random.Range(0, 3);
            Instantiate(easyList[randomIndex]);
        }
        //If normal pattern is choosen
        if(randomDifficulty == 2)
        {
            randomIndex = UnityEngine.Random.Range(0, 7);
            Instantiate(normalList[randomIndex]);
        }
        //If hard pattern is choosen
        if (randomDifficulty == 3)
        {
            randomIndex = UnityEngine.Random.Range(0, 4);
            Instantiate(hardList[randomIndex]);
        }
        StartCoroutine(SpawnEnemies());
    }

    //Raises the max difficulty until the hard difficulty is reached
    IEnumerator ChangeDifficulty()
    {
        if(difficulty != 3)
        {
            yield return new WaitForSeconds(difficultyInterval);
            difficulty++;
            difficultyInterval *= 2;
            this.gameObject.GetComponent<SoundEffectPlayer>().Play1();
            StartCoroutine(ChangeDifficulty());
        }
    }

    //Makes enemy spawn faster until it reaches a limit
    IEnumerator DecrementInterval()
    {
        yield return new WaitForSeconds(spawnerInterval*5);
        spawnerInterval /= 1.2f;
        if(spawnerInterval > 0.7f)
        {
            StartCoroutine(DecrementInterval());
        }
    }
}
