using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_rope : MonoBehaviour
{
    Rigidbody rigid;
    public Rigidbody enemy1;
    public Rigidbody enemy2;
    public Rigidbody enemy3;
    public Rigidbody rope;

    public GameObject enemy_rope; 
    bool pull;
    public float power;

    public Text timer;
    public GameObject win_text;
    public GameObject Rebutton;

    Animator anim;
    public Animator red1_anim;
    public Animator red2_anim;
    public Animator red3_anim;


    public GameObject player_floor;
    public GameObject enemy_floor;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        enemy1 = enemy1.GetComponent<Rigidbody>();
        enemy2 = enemy2.GetComponent<Rigidbody>();
        rope = rope.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        red1_anim = red1_anim.GetComponent<Animator>();
        red2_anim = red2_anim.GetComponent<Animator>();
        red3_anim = red3_anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pull = Input.GetButtonDown("Jump");
        whoiswinner();
        
    }

    void FixedUpdate()
    {
        if (enemy_rope.GetComponent<Enemy_rope>().g_start)
        {
            gamestart();
        }
      
    }
    
    void gamestart()
    {
        if (pull)
        {
            rigid.velocity = new Vector3(0, 0, -1) * power;
            enemy1.velocity = new Vector3(0, 0, -1) * power;
            enemy2.velocity = new Vector3(0, 0, -1) * power;
            enemy3.velocity = new Vector3(0, 0, -1) * power;
            rope.velocity = new Vector3(0, 0, -1) * power;
            anim.SetBool("isPull", true);
        }
    }

    public void show_button()
    {
        Time.timeScale = 0;
        Rebutton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(3);
        Rebutton.SetActive(false);
        Time.timeScale = 1;
    }
    void whoiswinner()  //1은 player win 2는 enemy win
    {
        if (timer.GetComponent<Stage2_Timer>().player_win)
        {
            Win();
        }
        else if (timer.GetComponent<Stage2_Timer>().enemy_win)
        {
            Lose();
        }
    }
    void Win()
    {
        //나중에 텍스트 삽입해서 you win! 보이게하자.
        win_text.SetActive(true);
        //적 다리 없애기
        enemy_floor.SetActive(false);
        //떨어지는 애니메이션적용
        red1_anim.SetBool("isFall", true);
        red2_anim.SetBool("isFall", true);
        red3_anim.SetBool("isFall", true);
        // 로비맵으로 가기
        CurrentStage.stage2_clear = true;
        Invoke("next_stage", 5);
    }

    void next_stage()
    {
        SceneManager.LoadScene(1);
    }

    void Lose()
    {
        player_floor.SetActive(false);
        anim.SetBool("isLose", true);
        Invoke("show_button", 2);
    }
}
