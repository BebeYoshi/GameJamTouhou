using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void loadSceneA(){
        SceneManager.LoadScene("Snowboard");
    }

    public void loadSceneB(){
        SceneManager.LoadScene("Cidade");
    }

    public void loadSceneC(){
        SceneManager.LoadScene("Snowballfight");
    }
}
