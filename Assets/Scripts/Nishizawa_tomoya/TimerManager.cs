using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField, Header("Timer表示用text")]
    TextMeshProUGUI TimerText;
    [SerializeField, Header("制限時間（秒）")]
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
        limittime += 1;     //クリア後に秒数の少数が切り捨てられるため＋1
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

    public void GameClear()      //ゲームクリアした時に呼び出す。
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

    public void TimerStop()        //タイマーをストップする関数
    {
        timestop = true;
    }
    public bool Getendtime()
    {
        return endtime;
    }
}

