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

        // ����ȭ �ɰ��� �ڵ��ƺ��� �״·���
        // ���߿� gameManager ���� stage1������ �۵��ϰ� ��������.
        isyhb = younghee.GetComponent<Younghee>().check;
        onechance = timer.GetComponent<Timer>().gamecontinue;

        // ���� �ڵ��Ɣf���� �����̰ų�, �ð��� �������� �װ�.
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
        //�̵��Լ�����
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
         // ������ �ݶ��̴����� ���߿��� �״����� �������ؼ� �ݶ��̴��� �߷»�� false. 
         //���߿� �ٽõ�����ư�� �ٽ� �Ѵ� true�� �ٲ�����.
         gameObject.GetComponent<BoxCollider>().enabled = false;
         gameObject.GetComponent<Rigidbody>().useGravity = false;
         anim.SetBool("isDead", true);
         audio.Play();
         Debug.Log("�׾���!");     
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
