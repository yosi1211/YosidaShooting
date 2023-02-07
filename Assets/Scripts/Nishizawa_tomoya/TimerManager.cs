using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField, Header("Timer�\���ptext")]
    TextMeshProUGUI TimerText;
    [SerializeField, Header("�������ԁi�b�j")]
    float limittime = 180f;

    float time = 0;
    int second;
    int minutu;

    static public int clearsecond;
    static public int clearminutu;

    bool timestop = false;
    bool endtime = false;

    void Start()
    {
        TimerText = TimerText.GetComponent<TextMeshProUGUI>();
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
        else if (time <= 0)
        {
            endtime = true;
        }
        minutu = (int)time / 60;
        second = (int)time % 60;
        string minutuText, secondText;

        if (minutu < 10)
        {
            minutuText = minutu.ToString();
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
    }

    public void TimerStart()
    {
        timestop = false;
    }

    public void TimerStop()        //�^�C�}�[���X�g�b�v����֐�
    {
        timestop = true;
    }
    public bool Getendtime()
    {
        return endtime;
    }
}

