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
    private bool calculatingNewRound;

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
            if (calculatingNewRound)
            {
                StartCoroutine(NewRound());
            }
            else if (PropController.success)
            {
                this.gameObject.GetComponent<SoundEffectPlayer>().Play1();
                ScoreJorge.Score(100 + ((int)difficulty/2) * 200);
                if (difficulty < maxDifficulty) difficulty++;
                calculatingNewRound = true;
            }
            else if (LinearTimer.ended)
            {
                this.gameObject.GetComponent<SoundEffectPlayer>().Play3();
                GameOver = true;
                ScoreJorge.FinaldeJogo();
            }
        }
    }

    IEnumerator NewRound()
    {
        
        LinearTimer.Stop();
        yield return new WaitForSeconds(1.0f / (1+difficulty));
        LinearTimer.Unstop();
        PropController.NewRound();
        LinearTimer.NewRound(maxTime - maxTime * difficulty / (maxDifficulty + 1));
        calculatingNewRound = false;
    }
}
