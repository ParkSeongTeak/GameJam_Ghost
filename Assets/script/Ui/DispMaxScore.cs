using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispMaxScore : MonoBehaviour
{
    Text ScoreText;
    int score;
     GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)GameManager.instance.GetMaxScore();
        ScoreText.text = GetScoreText(score);
    }
    public string GetScoreText(int score)
    {
        return string.Format("{0:#,###}", score);
    }
}
