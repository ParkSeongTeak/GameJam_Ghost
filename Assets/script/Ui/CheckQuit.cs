using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckQuit : MonoBehaviour
{
    private bool wtquit = false;
    public GameObject QuitUI;
    
    void Start()
    {
        QuitUI.SetActive(false);
    }

    void Update()
    {
        //종료 확인창 띄우기
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!wtquit)
                    {
                        //활성화
                        QuitUI.SetActive(true);
                    }
            else
                    {
                        //비활성화
                        QuitUI.SetActive(false);
                    }

            wtquit = !wtquit;
        }
        
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        //비활성화
        QuitUI.SetActive(false);
    }

}
