using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{

    [SerializeField, Header("�ȉ��V�[����")]
    string AllRanking = "All_Ranking";
    [SerializeField]
    string HardRanking = "Hard_Ranking";
    [SerializeField]
    string NormalRanking = "Normal_Ranking";
    [SerializeField]
    string EasyRanking = "Easy_Ranking";

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


    public void All_ranking()
    {
        SceneManager.LoadScene(AllRanking, LoadSceneMode.Additive);
    }

    void Hard_ranking()
    {
        SceneManager.LoadScene(HardRanking, LoadSceneMode.Additive);
    }

    void Normal_ranking()
    {
        SceneManager.LoadScene(NormalRanking, LoadSceneMode.Additive);
    }

    void Easy_ranking()
    {
        SceneManager.LoadScene(EasyRanking, LoadSceneMode.Additive);
    }
}
