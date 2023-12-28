using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float LimitTime;
    public GameObject younghee;
    public GameObject border;
    Text text_timer;
    public int gamecontinue;

    void Awake()
    {
        text_timer = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (gamecontinue < 2f && LimitTime >= 1f)
        {
            TimeGoing();
        }
        else
        {
            gamecontinue++;
            LimitTime = 60f;
            younghee.GetComponent<Younghee>().g_start = true;
            border.GetComponent<Bordermove>().g_start = true;
        }
    }

    void TimeGoing()
    {   
        LimitTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(LimitTime / 60);
        int sec = Mathf.FloorToInt(LimitTime % 60);
        text_timer.text = string.Format("{0:D2}:{1:D2}", min, sec);
    
    }

}
