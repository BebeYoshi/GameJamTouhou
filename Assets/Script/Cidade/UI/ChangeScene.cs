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
        Debug.Log("Cena C");
        SceneManager.LoadScene("Snowballfight");
    }

    public void loadSceneD(){
        SceneManager.LoadScene("Jorge");
    }

    public void loadSceneE(){
        SceneManager.LoadScene("Ending");
    }

    public void loadSceneF(){
        SceneManager.LoadScene("Beginning");
    }
}
