using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour
{

    int second;
    int minutu;
    float time = 0f;
    Text scoretext = null;

    private void Start()
    {
        scoretext = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
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

        if(second < 10)
        {
            secondText = "0" + second.ToString();
        }
        else
        {
            secondText = second.ToString();
        }

        scoretext.text = minutuText + ":" + secondText ;
    }

    public void TestTime()
    {
        //timeをスコアとして使う場合
        var timeScore = new System.TimeSpan(0, minutu, second);
        //var millsec = 123456;
        //var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 0);

        //数値をスコアとして使う場合
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(100);
    }
}
