using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_rest : MonoBehaviour
{
    float hAxis;
    float vAxis;
    Vector3 moveVec;
    public float speed;

    bool rDown;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        GetInput();
        Move();
        Look();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            // ù���� ����
            if (!CurrentStage.stage1_clear && !CurrentStage.stage2_clear && !CurrentStage.stage3_clear)
            {
                SceneManager.LoadScene(2);
            }
            //�ι�°���� ����
            else if (CurrentStage.stage1_clear)
            {
                SceneManager.LoadScene(3);
                CurrentStage.stage1_clear = false;
            }
            //����°���� ����
            else if(CurrentStage.stage2_clear)
            {
                SceneManager.LoadScene(4);
                CurrentStage.stage2_clear = false;
            }//�ٳ����� ������� ���ƿ���
            else if(CurrentStage.stage3_clear)
            {
                CurrentStage.stage3_clear = false;
                SceneManager.LoadScene(1);
            }

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
}
