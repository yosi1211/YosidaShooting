using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Active : MonoBehaviour
{
    [SerializeField, Header("それぞれの自機")]
    GameObject HardMachine;
    [SerializeField]
    GameObject NormalMachine;
    [SerializeField]
    GameObject EasyMachine;

    void Start()
    {
        HardMachine.SetActive(false);
        NormalMachine.SetActive(false);
        EasyMachine.SetActive(false);
        switch (Ownmachine_Inform.ownmachine)
        {
            case 0:
                HardMachine.SetActive(true);
                break;
            case 1:
                NormalMachine.SetActive(true);
                break;
            case 2:
                EasyMachine.SetActive(true);
                break;
            default:    //ここに来ることがあればエラー
                Debug.LogError("自機番号が正しくありません");
                EasyMachine.SetActive(true);
                break;
        }
    }
}
