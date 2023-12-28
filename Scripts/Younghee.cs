using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Younghee : MonoBehaviour
{

    public int nextturn;
    public bool check; //영희가 뒤돌아봤는지확인 
    public Text time;
    public bool g_start; //time 되면 게임시작
    bool b; //한번만 실행하도록

    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (g_start && !b)
        {
            GameStart();
            b = true;
        }       
    }

    public void GameStart()
    {
        if (g_start)
        {
            Debug.Log("게임을 시작하였습니다.");
            Turnback();
        }
    }
    public void Turn()  // 뒤돌아보기
    {
        Debug.Log("뒤돌아봤따!");
        check = true;
        //뒤돌아볼때 목소리끄기
        audio.mute = true;
        Invoke("Turnback", 3); // 뒤돌아보고 3초뒤에 다시 눈감게.
    }

    public void Turnback()  // 다시 돌아서 눈감기
    {
        Debug.Log("무궁화 꽃이 피었~");
        check = false;
        nextturn = Random.Range(3, 6); // 3~5까지
        //보이스틀기
        audio.mute = false;
        audio.Play();
        Invoke("Turn", nextturn);
    }
}
