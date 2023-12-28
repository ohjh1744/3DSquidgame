using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3_Timer : MonoBehaviour
{
    public float LimitTime;
    public GameObject border;
    Text text_timer;
    public int gamecontinue;
    public GameObject player;

    void Awake()
    {
        text_timer = GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (gamecontinue < 2 && LimitTime >= 1f)
        {
            TimeGoing();
        }
        else
        {
            gamecontinue++;
            if(gamecontinue == 2)
            {
                player.GetComponent<Player_glassbridge>().gamefinish = true;
            }
            player.GetComponent<Player_glassbridge>().gamestart = true;
            LimitTime = 60f;
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
