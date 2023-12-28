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
            // 첫라운드 들어가기
            if (!CurrentStage.stage1_clear && !CurrentStage.stage2_clear && !CurrentStage.stage3_clear)
            {
                SceneManager.LoadScene(2);
            }
            //두번째라운드 들어가기
            else if (CurrentStage.stage1_clear)
            {
                SceneManager.LoadScene(3);
                CurrentStage.stage1_clear = false;
            }
            //세번째라운드 들어가기
            else if(CurrentStage.stage2_clear)
            {
                SceneManager.LoadScene(4);
                CurrentStage.stage2_clear = false;
            }//다끝나면 원래대로 돌아오기
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
}
