using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Text_Sprite : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] lines;
    public int[] posicaoSprite;
    public Sprite[] listaSprites;
    public float textSpeed;
    public Scene_Changer endScene;
    public GameObject background;
    public GameObject ending;
    public Image sprite1;
    public Image sprite2;
    public Image sprite3;
    public bool isLily;
    
    private int i;
    // Start is called before the first frame update
    void Start(){
        changeSprite(0);
        text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.E)){
            if(text.text == lines [i]){
                nextLine();
            }
            else{
                StopAllCoroutines();
                text.text = lines[i];
            }
        }
    }

    void StartDialogue(){
        i = 0;
        StartCoroutine(ShowLine());
    }

    IEnumerator ShowLine(){
        foreach (char c in lines[i].ToCharArray()){
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine(){
        if(i < lines.Length -1){
            i++;
            text.text = string.Empty;
            changeSprite(i);
            StartCoroutine (ShowLine());
        }
        else {
            {
                endScene.handleScene(true);
                gameObject.SetActive(false);
            }
        }
    }

    void changeSprite(int i){
        if(posicaoSprite[i] == 1){
            sprite1.sprite = listaSprites[i];
            text.color = new Color32(226, 26, 26, 255);
            sprite2.color = new Color(1f,1f,1f,.8f);
            sprite3.color = new Color(1f,1f,1f,.8f);
            sprite1.color = new Color(1f,1f,1f,1f);
        }
        else if(posicaoSprite[i] == 2){
            sprite2.sprite = listaSprites[i];
            text.color = new Color32(217, 187, 9, 255);
            sprite1.color = new Color(1f,1f,1f,.8f);
            sprite3.color = new Color(1f,1f,1f,.8f);
            sprite2.color = new Color(1f,1f,1f,1f);
        }
        else{
            
            sprite3.sprite = listaSprites[i];
            if(isLily){
                text.color = new Color32(245, 211, 156, 255);
            }
            else {
                text.color = new Color32(217, 187, 9, 255);
            }
            sprite1.color = new Color(1f,1f,1f,.8f);
            sprite2.color = new Color(1f,1f,1f,.8f);
            sprite3.color = new Color(1f,1f,1f,1f);
        }
        
    }

}
