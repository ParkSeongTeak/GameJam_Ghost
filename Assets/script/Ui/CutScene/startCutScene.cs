using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startCutScene : MonoBehaviour
{
    bool startReady=false;
    public Sprite[] cutSceneSprites;
    int indexNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CutScene");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            
                StopCoroutine("CutScene");
                if(indexNum<4)
                {
                    indexNum++;
                gameObject.GetComponent<Image>().sprite=cutSceneSprites[indexNum];
                }
                else
                {
                     gameObject.transform.GetChild(0).gameObject.SetActive(true);
                }
                /*
                gameObject.GetComponent<Image>().sprite=cutSceneSprites[4];
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                */
                
            }
        
    }
    IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Image>().sprite=cutSceneSprites[1];
        indexNum=1;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Image>().sprite=cutSceneSprites[2];
        indexNum=2;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Image>().sprite=cutSceneSprites[3];
        indexNum=3;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Image>().sprite=cutSceneSprites[4];
        indexNum=4;
        yield return new WaitForSeconds(1f);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
