using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenButton : MonoBehaviour
{
    
    public void Yes_Button()
    {
        SceneManager.LoadScene(1);
    }

    // 마지막 종료하기에서도 이 스크립트꺼 사용.
    public void Quit_Button()
    {
        Application.Quit();
    }
}
