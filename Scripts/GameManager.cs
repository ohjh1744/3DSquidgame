using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public GameObject Stage_name;
    public Text stage_name_text;

    public GameObject Stage_Explanation;
    public Text stage_Explanation_text;

    public GameObject Game_clear;

    public GameObject Jump_text;
    public GameObject Pull_text;
    public GameObject Quit_button;
    


    void Awake()
    {
        //2라운드
        if (CurrentStage.stage1_clear)
        {
            stage_name_text.text = "Stage 2 : 줄다리기";
            stage_Explanation_text.text = "게임 설명: 상대편과 줄다리기 대결을 한다. 입장하면 10초뒤에 게임은 시작된다. 주어진 시간내에 상대보다 줄을 더 당기면 승리한다. (Tip: 스페이스바 연타)";
            Pull_text.SetActive(true);
            
        }
        //3라운드
        else if(CurrentStage.stage2_clear)
        {
            stage_name_text.text = "Stage 3 : 유리다리건너기";
            stage_Explanation_text.text = "게임 설명: 게임에 입장하면 앞에 14짝을 이루는 유리다리가 보일것이다. 주어진 시간내에 유리다리를 건너 출구까지 들어가라. (TIP: 유리를 자세히 보아라. 반짝일것이니..)";
            Pull_text.SetActive(false);
            Jump_text.SetActive(true);
        }
        else if(CurrentStage.stage3_clear)
        {
            stage_name_text.text = "Stage 3 : 유리다리건너기";
            stage_Explanation_text.text = "게임 설명: 게임에 입장하면 앞에 14짝을 이루는 유리다리가 보일것이다. 주어진 시간내에 유리다리를 건너 출구까지 들어가라. (TIP: 유리를 자세히 보아라. 반짝일것이니..)";
            Pull_text.SetActive(false);
            Jump_text.SetActive(true);
            Game_clear.SetActive(true);
            Quit_button.SetActive(true);

        }
    }


}
