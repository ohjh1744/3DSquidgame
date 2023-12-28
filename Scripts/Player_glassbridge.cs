using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_glassbridge : MonoBehaviour
{

    float hAxis;
    float vAxis;
    Vector3 moveVec;
    public float speed;

    bool rDown;
    bool isjump;
    bool jDown;
    public int jPower;
    Rigidbody rigid;

    Animator anim;

    public GameObject Rebutton;

    public GameObject[] odd_glass;
    public GameObject[] even_glass;
    public GameObject[] fake_glass;

    public Material rg_mat;
    public Material fg_mat;

    AudioSource audio;
    public AudioClip broken_glass;
    public AudioClip gun;

    public bool gamestart;
    public bool gamefinish;

    bool co_ing;
    bool time_set; // update함수에서 audio.play가 게속진행되서 소리가 안들림. 한번만 실행하게하기위한 변수.


    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        fake_glass = new GameObject[14];
        choose_randomglass();
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        GetInput();
        Move();
        Jump();
        Look();
        if (gamestart && !co_ing)
        {
            co_ing = true;
            StartCoroutine("shining");
        }
        //시간초과하면 죽음.
        if (gamefinish && !time_set)
        {
            time_set = true;
            audio.clip = gun;
            audio.Play();
            Dead();
            Invoke("show_button", 0.8f);
        }

    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        rDown = Input.GetButton("Run");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        //이동함수로직
        anim.SetBool("isWalk", moveVec != Vector3.zero);
        anim.SetBool("isRun", rDown);
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * (rDown ? 1.5f : 1f) * Time.deltaTime;
    }

    void Jump()
    {
        if (jDown && !isjump)
        {
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector3.up * jPower, ForceMode.Impulse);
            isjump = true;
        }
    }

    void Look()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Dead()
    {
        // 죽을때 콜라이더때매 공중에서 죽는현상 막기위해서 콜라이더와 중력사용 false. 
        // stage3에선 콜라이더 코드뺌. 그게더 자연스러워보여서
        //나중에 다시도전버튼에 다시 둘다 true로 바꿔주자.
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        anim.SetBool("isDead", true);
        Debug.Log("죽었따!");
    }

    void OnCollisionEnter(Collision collision)
    {
        //2단점프방지
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Glass")
        {
            isjump = false;
            anim.SetBool("isJump", false);
        }

        //Dieborder에 닿을시 retry
        if(collision.gameObject.tag == "DieBorder")
        {
            show_button();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glass")
        {
            other.gameObject.SetActive(false);
            audio.clip = broken_glass;
            audio.Play();
            //애니메이션 겹침방지
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", true);
        }

        if(other.gameObject.tag == "Finish")
        {
            CurrentStage.stage3_clear = true;
            SceneManager.LoadScene(1);
        }
    }


    public void show_button()
    {
        Time.timeScale = 0;
        Rebutton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(4);
        Rebutton.SetActive(false);
        Time.timeScale = 1;
    }


    void choose_randomglass()
    {
        for(int i = 0; i < 14; i++)
        {
            int c = Random.Range(1, 3); // 1~2
            if(c == 1)
            {
                odd_glass[i].GetComponent<Collider>().isTrigger = true;
                fake_glass[i] = odd_glass[i];
                Debug.Log("odd_glass" + i);
            }
            else
            {
                even_glass[i].GetComponent<Collider>().isTrigger = true;
                fake_glass[i] = even_glass[i];
                Debug.Log("even_glass" + i);
            }
        }
    }

    IEnumerator shining()
    {
        yield return new WaitForSeconds(6f);
        for(int i = 0; i < 14; i++)
        {
            fake_glass[i].GetComponent<MeshRenderer>().material = fg_mat; 
        }
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 14; i++)
        {
            fake_glass[i].GetComponent<MeshRenderer>().material = rg_mat;
        }
        co_ing = false;
    }
}
