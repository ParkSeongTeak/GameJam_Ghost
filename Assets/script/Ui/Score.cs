using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    double TimeBonus = 1;
    public double score = 0;
    // Start is called before the first frame update

    void FixedUpdate()
    {
        score += GameManager.instance.GhostCounting() * Time.deltaTime * TimeBonus * 10;
        TimeBonus += 0.01;
       // Debug.Log(score);
    }


}