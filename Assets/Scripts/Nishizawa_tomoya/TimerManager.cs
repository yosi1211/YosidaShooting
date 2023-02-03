using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    //ゲームをクリアした時にタイマーをストップする必要がある
    [SerializeField, Header("RankingManager参照用")]
    RankingManager rankingManager;
    [SerializeField, Header("Timer表示用text")]
    Text TimerText;
    [SerializeField, Header("制限時間（秒）")]
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
        else if (time == 0)
        {
            //制限時間切れ ゲームオーバー
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

    public void GameClear()      //ゲームクリアした時に呼び出す。
    {
        TimerStop();
        limittime -= time;
        clearminutu = (int)limittime / 60;
        clearsecond = (int)limittime % 60;
        rankingManager.ownmachine_ranking();
    }

    public bool TimerStop()        //タイマーをストップする関数
    {
        timestop = true;
        return timestop;
    }
}

