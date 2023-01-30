using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Sprite : MonoBehaviour
{
    // Start is called before the first frameaaa update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeSprite(Sprite a){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
    }
}
