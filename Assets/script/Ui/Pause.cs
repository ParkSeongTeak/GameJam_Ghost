using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool pauseOn = false;
    public GameObject PauseUI;
    public GameObject pausebt;

    
   void Start()
    {
        PauseUI.SetActive(false);
    }

    public void PressPause()
    {
        //일시정지
        if (!pauseOn)
        {
            Time.timeScale = 0;
            PauseUI.SetActive(true);
            //일시정지버튼 숨기기
            pausebt.SetActive(false);
        }
        else
        {
            //일시정지 해제
            Time.timeScale = 1.0f;
            PauseUI.SetActive(false);
            //일시정지버튼 보이기
            pausebt.SetActive(true);
        }

        pauseOn = !pauseOn;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }    

    public void PressRetry()
    {
        //게임 재시작
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
