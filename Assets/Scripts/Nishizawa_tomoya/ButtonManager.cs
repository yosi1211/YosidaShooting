using SceneaManger;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField, Header("移動先のシーン名")]
    string SceneName;

    [SerializeField, Header("シーン移動クラス参照")]
    SceneManagerController scenemanager;

    [SerializeField, Header("マシンセレクト画面")]
    GameObject machineSelect_Canvas;

    private void Start()
    {
        machineSelect_Canvas.SetActive(false);
    }

    public void START_OnClick()
    {
        machineSelect_Canvas.SetActive(true);
    }

    public void Hardmachine_Select_OnClick()
    {
        Ownmachine_Inform.ownmachine = 0;
        scenemanager.LoadScene(SceneName);
    }

    public void Normalmachine_BSelect_OnClick()
    {
        Ownmachine_Inform.ownmachine = 1;
        scenemanager.LoadScene(SceneName);
    }

    public void Easymachine_CSelect_OnClick()
    {
        Ownmachine_Inform.ownmachine = 2;
        scenemanager.LoadScene(SceneName);
    }
}