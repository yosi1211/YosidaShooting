using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ownmachine_Inform : MonoBehaviour
{
    //ゲームのシーンから自機の情報を持ってくるクラス
    //ゲームのスコアもまとめて持ってきてもいいかも
    static public int ownmachine = 0;

    private void Start()
    {
        ownmachine = 0;
    }

#if DEBUG
    public void Ziki_counttest()
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
#endif

}
