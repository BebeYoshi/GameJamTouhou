using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    
    public GameObject background;
    public GameObject ending;
    public GameObject statistics;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleScene(bool isEndScene){
        if(isEndScene){
                background.SetActive(true);
                ending.SetActive(true);
                statistics.SetActive(true);
        }
        else{
            SceneManager.LoadScene("Cidade");
        }
    }
}
