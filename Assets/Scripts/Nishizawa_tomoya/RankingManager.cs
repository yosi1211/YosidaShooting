using UnityEngine;

public class RankingManager : MonoBehaviour
{
    enum MACHINE_TYPE
    {
        A_MACHINE = 0,
        B_MACHINE,
        C_MACHINE
    }

    //[SerializeField] int ownmachine = 0;
    [SerializeField] TimeTest TimeTest;
    public void ownmachine_ranking()
    {
        switch (Ownmachine_Inform.ownmachine)//�n����Ă������@�̃i���o�[������\��
        {
            case (int)MACHINE_TYPE.A_MACHINE:         //���@A�̏ꍇ
                A_ranking();
                break;
            case (int)MACHINE_TYPE.B_MACHINE:         //���@B�̏ꍇ
                B_ranking();
                break;
            case (int)MACHINE_TYPE.C_MACHINE:         //���@C�̏ꍇ
                C_ranking();
                break;
            default:
                break;
        }
    }

    /**********Debug�p�A���@�ύX***************/
/*#if DEBUG
    public void ziki_counttest()
    {
        if (ownmachine < 2)
        {
            ownmachine++;
            Debug.Log(ownmachine);
        }
        else
        {
            ownmachine = 0;
            Debug.Log(ownmachine);
        }
    }
#endif*/
    /*******************************************/

    public void All_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimeTest.minutu, TimeTest.second);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 0);
        //��������������ƕ\�����郉���L���O��ύX�ł���
    }

    public void A_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimeTest.minutu, TimeTest.second);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 1);
    }

    public void B_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimeTest.minutu, TimeTest.second);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 2);
    }

    public void C_ranking()
    {
        var timeScore = new System.TimeSpan(0, TimeTest.minutu, TimeTest.second);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 3);
    }
}
