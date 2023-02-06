using UnityEngine;

public class RankingManager : MonoBehaviour
{
    enum MACHINE_TYPE
    {
        HARD_MACHINE = 0,
        NORMAL_MACHINE,
        EASY_MACHINE
    }

    public void Call_Ranking()    //�����L���O���o���Ƃ��Ă�
    {
        switch (Ownmachine_Inform.ownmachine)//�n����Ă������@�̏�������
        {
            case (int)MACHINE_TYPE.HARD_MACHINE:         //���@A�̏ꍇ
                Hard_ranking();
                break;
            case (int)MACHINE_TYPE.NORMAL_MACHINE:         //���@B�̏ꍇ
                Normal_ranking();
                break;
            case (int)MACHINE_TYPE.EASY_MACHINE:         //���@C�̏ꍇ
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
        //��������������ƕ\�����郉���L���O��ύX�ł���
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
