using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    //�Q�[�����N���A�������Ƀ^�C�}�[���X�g�b�v����K�v������
    [SerializeField, Header("RankingManager�Q�Ɨp")]
    RankingManager rankingManager;
    [SerializeField, Header("Timer�\���ptext")]
    Text TimerText;
    [SerializeField, Header("�������ԁi�b�j")]
    float limittime = 180f;

    float time = 0;
    int second;
    int minutu;

    static public int clearsecond;
    static public int clearminutu;

    bool timestop = false;

    void Start()
    {
        TimerText = TimerText.GetComponent<Text>();
        limittime += 1;     //�N���A��ɕb���̏������؂�̂Ă��邽�߁{1
        time = limittime;
    }

    void Update()
    {
        if (time >= 0)
        {
            if (!timestop)
            {
                time -= Time.deltaTime;
            }
        }
        else if (time == 0)
        {
            //�������Ԑ؂� �Q�[���I�[�o�[
        }
        minutu = (int)time / 60;
        second = (int)time % 60;
        string minutuText, secondText;

        if (minutu < 10)
        {
            minutuText = "0" + minutu.ToString();
        }
        else
        {
            minutuText = minutu.ToString();
        }

        if (second < 10)
        {
            secondText = "0" + second.ToString();
        }
        else
        {
            secondText = second.ToString();
        }

        TimerText.text = minutuText + ":" + secondText;
    }

    public void GameClear()      //�Q�[���N���A�������ɌĂяo���B
    {
        TimerStop();
        limittime -= time;
        clearminutu = (int)limittime / 60;
        clearsecond = (int)limittime % 60;
        rankingManager.ownmachine_ranking();
    }

    public bool TimerStop()        //�^�C�}�[���X�g�b�v����֐�
    {
        timestop = true;
        return timestop;
    }
}

