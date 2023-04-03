using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;


public class Candy_Generator : MonoBehaviour
{
    public float start;
    public GameObject Something;
    public Sprite[] SomethingSprites;
    public int spritesnum = 1;
    float time;
    public int RAND;
    float num = 1;
    public AudioSource throwsoundone;
    public AudioSource throwsoundtwo;
    public AudioSource throwsoundthree;
    bool doGenerate = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate_());
        //StartCoroutine(TimerCor());
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (15 > time)
            num = 1F;
        else if (30 > time)
            num = 1.2F;
        else if (45 > time)
            num = 1.4F;
        else if (60 > time)
            num = 1.5F;
        else
            num = 1.9F;

    }
    IEnumerator Generate_()
    {
        if (doGenerate)
        {            
            float axelTemp;
            int r = Random.Range(0, 3);
            bool hasGravity = false;
            switch (r)
            {
                //candy1
                case 0:
                    axelTemp = 1;
                    throwsoundone.Play();
                    break;
                //candy2
                case 1:
                    axelTemp = 0.7f;
                    throwsoundtwo.Play();
                    break;
                //candy3
                case 2:
                    axelTemp = 0.5f;
                    hasGravity = true;
                    throwsoundthree.Play();
                    break;
                default:
                    axelTemp = 1;
                    break;
            }

            GameObject Some = Instantiate(Something, new Vector3(start, Random.Range(-4, 4), 0), transform.rotation);
            if (hasGravity)
            {
                Some.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                Some.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 3), ForceMode2D.Impulse);
            }
            else
            {
                Some.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            Some.GetComponent<Move_SomeThing>().Accelerate = axelTemp * num;
            Some.GetComponent<SpriteRenderer>().sprite = SomethingSprites[r];
        }
        yield return new WaitForSeconds(Random.Range(2F / num, 5F / num));  //탄 생성속도 원한다면 조정

        StartCoroutine(Generate_());
    }

    IEnumerator TimerCor()
    {
        yield return new WaitForSeconds(15f);
        doGenerate = false;
        Debug.Log("stop");
        yield return new WaitForSeconds(3f);
        doGenerate = true;
        Debug.Log("reStart");
        yield return new WaitForSeconds(12f);
        doGenerate = false;
        Debug.Log("stop");
        yield return new WaitForSeconds(3f);
        doGenerate = true;
        Debug.Log("reStart");
        yield return new WaitForSeconds(12f);
        doGenerate = false;
        Debug.Log("stop");
        yield return new WaitForSeconds(3f);
        doGenerate = true;
        Debug.Log("reStart");
        yield return new WaitForSeconds(12f);
        doGenerate = false;
        Debug.Log("stop");
        yield return new WaitForSeconds(3f);
        doGenerate = true;
        Debug.Log("reStart");
    }




    IEnumerator WaitForSecondsCoroutine(float delay)                           //딜레이
    {
        yield return new WaitForSeconds(delay);
    }



    float Accel(int num)
    {

        if (num == 0)
            return 1;
        else if (num == 1)
            return 0.75F;
        else
            return 0.5F;

    }
}

