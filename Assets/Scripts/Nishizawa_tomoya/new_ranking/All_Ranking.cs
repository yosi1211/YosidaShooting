using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using SceneaManger;

public class All_Ranking : MonoBehaviour
{
    [SerializeField,Header("���[�U�[���e�L�X�g")]
    TextMeshProUGUI[] usernameText = new TextMeshProUGUI[5];
    [SerializeField, Header("�X�R�A�e�L�X�g")]
    TextMeshProUGUI[] rankingText = new TextMeshProUGUI[5];
    [SerializeField, Header("���O���̓C���v�b�g�t�B�[���h")]
    InputField InputField;
    [SerializeField, Header("���M�{�^��")]
    Button SendButton;
    [SerializeField, Header("�V�[���ړ��N���X�Q��")]
    SceneManagerController scenemanager;
    [SerializeField, Header("�^�C�g���V�[����")]
    string titleSceneName = "TitleScene";

    int clearminutu;
    int clearsecond;
    int time = 0;

    string[] Name_ranking_key = { "name1", "name2", "name3", "name4", "name5" };
    string userName;
    string[] userValue = new string[5];

    int[] Minitu_ranking = new int[5];
    int[] Second_ranking = new int[5];

    string[] ranking_key = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };
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


    public void AllRanking()
    {

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
            rankingValue[i] = PlayerPrefs.GetInt(ranking_key[i], 3600);
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

    /*DEBUG*/
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
    /**/

    public void closeOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("All_Ranking");
        //�^�C�g���V�[���ɖ߂�
        scenemanager.LoadScene(titleSceneName);
    }
}
