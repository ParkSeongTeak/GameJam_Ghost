using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispScore : MonoBehaviour
{
    Text ScoreText;
    int score;
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
        
    }
    
    void Update()
    {
        score = (int)GameObject.Find("Main Camera").GetComponent<Score>().score;
        ScoreText.text = GetScoreText(score);
    }
    public string GetScoreText(int score)
    {
        return string.Format("{0:#,###}", score);
    }
}
