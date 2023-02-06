using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{

    [SerializeField, Header("以下シーン名")]
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
