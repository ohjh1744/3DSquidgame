using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int jPower;
    bool isjump;
    float hAxis;
    float vAxis;
    Vector3 moveVec;
    Animator anim;
    bool rDown;
    bool jDown;
    public GameObject younghee;
    bool isyhb;
    Rigidbody rigid;

    public Text timer;
    int onechance;
    public GameObject Rebutton;

    AudioSource audio;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        GetInput();
        Move();
        Look();

        // 무궁화 꽃게임 뒤돌아볼때 죽는로직
        // 나중에 gameManager 만들어서 stage1에서만 작동하게 관리하자.
        isyhb = younghee.GetComponent<Younghee>().check;
        onechance = timer.GetComponent<Timer>().gamecontinue;

        // 영희가 뒤돌아봣을때 움직이거나, 시간이 다지나면 죽게.
        if (isyhb)
        {
            if(moveVec != Vector3.zero) 
            {
                Dead();
                Invoke("show_button", 1);
                              
            }
        }
        else if(onechance > 1)
        {
            Dead();
            Invoke("show_button", 1);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            CurrentStage.stage1_clear = true;
            SceneManager.LoadScene(1);
        }
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        rDown = Input.GetButton("Run");
    }

    void Move()
    {
        //이동함수로직
        anim.SetBool("isWalk", moveVec != Vector3.zero);
        anim.SetBool("isRun", rDown);
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * (rDown ? 1.5f : 1f) * Time.deltaTime;
    }

    void Look()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Dead()
    {
         // 죽을때 콜라이더때매 공중에서 죽는현상 막기위해서 콜라이더와 중력사용 false. 
         //나중에 다시도전버튼에 다시 둘다 true로 바꿔주자.
         gameObject.GetComponent<BoxCollider>().enabled = false;
         gameObject.GetComponent<Rigidbody>().useGravity = false;
         anim.SetBool("isDead", true);
         audio.Play();
         Debug.Log("죽었따!");     
    }

    public void show_button()
    {
        Time.timeScale = 0;
        Rebutton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        Rebutton.SetActive(false);
        Time.timeScale = 1;
    }
}
