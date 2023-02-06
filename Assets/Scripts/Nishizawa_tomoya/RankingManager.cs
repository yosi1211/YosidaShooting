using UnityEngine;

public class RankingManager : MonoBehaviour
{
    enum MACHINE_TYPE
    {
        HARD_MACHINE = 0,
        NORMAL_MACHINE,
        EASY_MACHINE
    }

    public void Call_Ranking()    //ランキングを出すとき呼ぶ
    {
        switch (Ownmachine_Inform.ownmachine)//渡されてきた自機の情報を入れる
        {
            case (int)MACHINE_TYPE.HARD_MACHINE:         //自機Aの場合
                Hard_ranking();
                break;
            case (int)MACHINE_TYPE.NORMAL_MACHINE:         //自機Bの場合
                Normal_ranking();
                break;
            case (int)MACHINE_TYPE.EASY_MACHINE:         //自機Cの場合
                Easy_ranking();
                break;
            default:
                break;
        }
    }


    void All_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimerManager.clearminutu, TimerManager.clearsecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 0);
        //第二引数をいじると表示するランキングを変更できる
    }

    void Hard_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimerManager.clearminutu, TimerManager.clearsecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 1);
    }

    void Normal_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimerManager.clearminutu, TimerManager.clearsecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 2);
    }

    void Easy_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimerManager.clearminutu, TimerManager.clearsecond);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 3);
    }
}
