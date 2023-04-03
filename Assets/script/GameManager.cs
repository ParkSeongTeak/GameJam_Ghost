using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Max_score = 0;
    public bool newScore;

    public int GhostCount = 3;
    int RandomNum = 1;

    private void Awake()
    {
        instance = this;
        
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Max_score")) Max_score = PlayerPrefs.GetInt("Max_score");
        else Max_score = 0;
    }

    void Update()
    {
        RandomNum = Random.Range(1, 10);
    }

    public int GetRandNum()
    {
        return RandomNum;
    }

    public int GhostCounting()
    {
        return GhostCount;
    }

    public void GhostMinus()
    {
        GhostCount -= 1;
    }

    public int GetMaxScore()
    {
        return Max_score;
    }

    public void GameOver(int thisScore)
    {
        if (thisScore > Max_score)
        {
            PlayerPrefs.SetInt("Max_score", thisScore);
            newScore = true;
        }
        else newScore = false;
    } // 신기록이면 true 반환
}



