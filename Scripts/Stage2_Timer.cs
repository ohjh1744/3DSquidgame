using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Timer : MonoBehaviour
{
    public float LimitTime;
    Text text_timer;
    public int gamecontinue;
    public Enemy_rope enemy_rope;

    public GameObject player;
    public GameObject enemy;
    public GameObject offset;

    public bool player_win;
    public bool enemy_win;

    void Awake()
    {
        text_timer = GetComponent<Text>();
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
                check_winner();
            }
            LimitTime = 20f;
            enemy_rope.GetComponent<Enemy_rope>().g_start = true;
        }
    }

    void TimeGoing()
    {
        LimitTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(LimitTime / 60);
        int sec = Mathf.FloorToInt(LimitTime % 60);
        text_timer.text = string.Format("{0:D2}:{1:D2}", min, sec);

    }

    void check_winner()
    {
        float player_position = player.GetComponent<Transform>().position.z;
        float enemy_position = enemy.GetComponent<Transform>().position.z;
        float offset_position = offset.GetComponent<Transform>().position.z;

        if(Mathf.Abs(player_position - offset_position) > Mathf.Abs(enemy_position - offset_position))
        {
            player_win = true;
        }
        else
        {
            enemy_win = true;
        }
    }
}
