using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRotation : MonoBehaviour
{
    public GameObject Target;
    public GameObject Canvas;
    public GameObject EatEffect;
    Animator animator;
    public AudioSource diesound;
    public bool gameOver=false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        if(! animator.GetBool("Die"))   transform.position = Target.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "New tag")
        {
            StartCoroutine("Die");
        }
        if(col.gameObject.tag=="Candy_Tag")
        {
            //Debug.Log("Candy");
            GameObject.Find("Main Camera").GetComponent<Score>().score+=500;
            GameObject.Find("CandySound").GetComponent<AudioSource>().Play();
            StartCoroutine("EatCandy");
            Destroy(col.gameObject);
        }
    }


    IEnumerator EatCandy()
    {
        GameObject obj = Instantiate(EatEffect, transform.position, Quaternion.identity);
        obj.transform.parent = gameObject.transform;

        yield return new WaitForSeconds(2f);

        Destroy(obj);
    }
    IEnumerator Die()
    {
        GameManager.instance.GhostMinus();
        GetComponent<Collider2D>().enabled = false;
        animator.SetBool("Die", true);
        diesound.Play();
        
        yield return new WaitForSeconds(3.5f);

        if (GameManager.instance.GhostCount < 1) GameOver();
        gameObject.SetActive(false);
    }

    void GameOver()
    {
        GameManager.instance.GameOver((int)GameObject.Find("Main Camera").GetComponent<Score>().score);
        Canvas.transform.Find("GameOverPanel").gameObject.SetActive(true);
        if (GameManager.instance.newScore) Canvas.transform.Find("GameOverPanel").transform.Find("NewRecord").gameObject.SetActive(true);
    }
}
