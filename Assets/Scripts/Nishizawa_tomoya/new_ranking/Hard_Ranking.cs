using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hard_Ranking : MonoBehaviour
{
    [SerializeField, Header("���[�U�[���e�L�X�g")]
    TextMeshProUGUI[] usernameText = new TextMeshProUGUI[5];
    [SerializeField, Header("�X�R�A�e�L�X�g")]
    TextMeshProUGUI[] rankingText = new TextMeshProUGUI[5];
    [SerializeField, Header("���O���̓C���v�b�g�t�B�[���h")]
    InputField InputField;
    [SerializeField, Header("���M�{�^��")]
    Button SendButton;
    [SerializeField, Header("���������L���O�̃V�[����")]
    string All_Ranking = "All_Ranking";

    int clearminutu;
    int clearsecond;
    int time = 0;

    string[] Name_ranking_key = { "Hname1", "Hname2", "Hname3", "Hname4", "Hname5" };
    string userName;
    string[] userValue = new string[5];

    int[] Minitu_ranking = new int[5];
    int[] Second_ranking = new int[5];

    string[] ranking_key = { "H�����L���O1��", "H�����L���O2��", "H�����L���O3��", "H�����L���O4��", "H�����L���O5��" };
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

    public void HardRanking()
    {
        GetRanking();

        userName = InputField.text;

        clearminutu = TimerManager.clearminutu;
        clearsecond = TimerManager.clearsecond;

        time = clearminutu * 60 + clearsecond;  //time�̕ϊ�

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
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking_key.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking_key[i], 180);
            userValue[i] = PlayerPrefs.GetString(Name_ranking_key[i], "---");
        }
    }

    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(int time, string username)
    {
        //�������ݗp
        for (int i = 0; i < ranking_key.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
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

        //����ւ����l��ۑ�
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
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Hard_Ranking");
        SceneManager.LoadScene(All_Ranking, LoadSceneMode.Additive);
    }
}
