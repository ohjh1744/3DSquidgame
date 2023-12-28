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
        //2����
        if (CurrentStage.stage1_clear)
        {
            stage_name_text.text = "Stage 2 : �ٴٸ���";
            stage_Explanation_text.text = "���� ����: ������ �ٴٸ��� ����� �Ѵ�. �����ϸ� 10�ʵڿ� ������ ���۵ȴ�. �־��� �ð����� ��뺸�� ���� �� ���� �¸��Ѵ�. (Tip: �����̽��� ��Ÿ)";
            Pull_text.SetActive(true);
            
        }
        //3����
        else if(CurrentStage.stage2_clear)
        {
            stage_name_text.text = "Stage 3 : �����ٸ��ǳʱ�";
            stage_Explanation_text.text = "���� ����: ���ӿ� �����ϸ� �տ� 14¦�� �̷�� �����ٸ��� ���ϰ��̴�. �־��� �ð����� �����ٸ��� �ǳ� �ⱸ���� ����. (TIP: ������ �ڼ��� ���ƶ�. ��¦�ϰ��̴�..)";
            Pull_text.SetActive(false);
            Jump_text.SetActive(true);
        }
        else if(CurrentStage.stage3_clear)
        {
            stage_name_text.text = "Stage 3 : �����ٸ��ǳʱ�";
            stage_Explanation_text.text = "���� ����: ���ӿ� �����ϸ� �տ� 14¦�� �̷�� �����ٸ��� ���ϰ��̴�. �־��� �ð����� �����ٸ��� �ǳ� �ⱸ���� ����. (TIP: ������ �ڼ��� ���ƶ�. ��¦�ϰ��̴�..)";
            Pull_text.SetActive(false);
            Jump_text.SetActive(true);
            Game_clear.SetActive(true);
            Quit_button.SetActive(true);

        }
    }


}
