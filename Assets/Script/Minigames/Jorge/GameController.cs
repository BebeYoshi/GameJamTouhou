using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject LinearTimerObj;
    public GameObject PropControllerObj;
    public GameObject ScoreJorgeObj;
    private LinearTimer LinearTimer;
    private PropController PropController;
    private ScoreJorge ScoreJorge;
    public bool GameOver;
    public int difficulty;
    public int maxDifficulty;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        LinearTimer = LinearTimerObj.GetComponent<LinearTimer>();
        PropController = PropControllerObj.GetComponent<PropController>();
        ScoreJorge = ScoreJorgeObj.GetComponent<ScoreJorge>();
        GameOver = false;
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (PropController.success)
            {
                if (difficulty < maxDifficulty) difficulty++;
                ScoreJorge.Score();
                PropController.NewRound();
                LinearTimer.NewRound(maxTime - maxTime * difficulty / (maxDifficulty+1));
            }
            else if (LinearTimer.ended)
            {
                GameOver = true;
                ScoreJorge.FinaldeJogo();
            }
        }
    }
}
