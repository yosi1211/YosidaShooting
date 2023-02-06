using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Easy_Ranking : MonoBehaviour
{
    [SerializeField, Header("ユーザー名テキスト")]
    TextMeshProUGUI[] usernameText = new TextMeshProUGUI[5];
    [SerializeField, Header("スコアテキスト")]
    TextMeshProUGUI[] rankingText = new TextMeshProUGUI[5];
    [SerializeField, Header("名前入力インプットフィールド")]
    InputField InputField;
    [SerializeField, Header("送信ボタン")]
    Button SendButton;
    [SerializeField, Header("総合ランキングのシーン名")]
    string All_Ranking = "All_Ranking";

    int clearminutu;
    int clearsecond;
    int time = 0;

    string[] Name_ranking_key = { "Ename1", "Ename2", "Ename3", "Ename4", "Ename5" };
    string userName;
    string[] userValue = new string[5];

    int[] Minitu_ranking = new int[5];
    int[] Second_ranking = new int[5];

    string[] ranking_key = { "Eランキング1位", "Eランキング2位", "Eランキング3位", "Eランキング4位", "Eランキング5位" };
    int[] rankingValue = new int[5];


    private void Start()
    {
        InputField = InputField.GetComponent<InputField>();
        SendButton = SendButton.GetComponent<Button>();

        SendButton.interactable = true;

        GetRanking();

        for (int i = 0; i < ranking_key.Length; i++)
        {
            Minitu_ranking[i] = rankingValue[i] / 60;
            Second_ranking[i] = rankingValue[i] % 60;
        }

        for (int i = 0; i < rankingText.Length; i++)
        {
            usernameText[i].text = userValue[i];
            if (Second_ranking[i] >= 10)
            {
                rankingText[i].text = Minitu_ranking[i].ToString() + ":" + Second_ranking[i].ToString();
            }
            else
            {
                rankingText[i].text = Minitu_ranking[i].ToString() + ":0" + Second_ranking[i].ToString();
            }
        }
    }


    public void EasyRanking()
    {
        GetRanking();

        userName = InputField.text;

        clearminutu = TimerManager.clearminutu;
        clearsecond = TimerManager.clearsecond;

        time = clearminutu * 60 + clearsecond;  //timeの変換

        SetRanking(time, userName);

        for (int i = 0; i < ranking_key.Length; i++)
        {
            Minitu_ranking[i] = rankingValue[i] / 60;
            Second_ranking[i] = rankingValue[i] % 60;
        }

        for (int i = 0; i < rankingText.Length; i++)
        {
            usernameText[i].text = userValue[i];
            if (Second_ranking[i] >= 10)
            {
                rankingText[i].text = Minitu_ranking[i].ToString() + ":" + Second_ranking[i].ToString();
            }
            else
            {
                rankingText[i].text = Minitu_ranking[i].ToString() + ":0" + Second_ranking[i].ToString();
            }
        }
        SendButton.interactable = false;
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking_key.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking_key[i], 3600);
            userValue[i] = PlayerPrefs.GetString(Name_ranking_key[i], "---");
        }
    }

    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int time, string username)
    {
        //書き込み用
        for (int i = 0; i < ranking_key.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (time < rankingValue[i])
            {
                var change = time;
                time = rankingValue[i];
                rankingValue[i] = change;

                var namechange = username;
                username = userValue[i];
                userValue[i] = namechange;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking_key.Length; i++)
        {
            PlayerPrefs.SetInt(ranking_key[i], rankingValue[i]);
        }
        for (int i = 0; i < Name_ranking_key.Length; i++)
        {
            PlayerPrefs.SetString(Name_ranking_key[i], userValue[i]);
        }

    }
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();

    }


    public void closeOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Easy_Ranking");
        SceneManager.LoadScene(All_Ranking, LoadSceneMode.Additive);
    }
}
