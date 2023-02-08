using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using playermanager;

public class ZankiText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Zankitext;
    [SerializeField,Header("0:ハード,1:ノーマル,2:イージー")]
    PlayerManager[] playermanager = new PlayerManager[3];

    void Start()
    {
        Zankitext = Zankitext.GetComponent<TextMeshProUGUI>();
        for(int i=0;i < playermanager.Length;i++)
        {
            playermanager[i] = playermanager[i].GetComponent<PlayerManager>();
        }
    }

    void Update()
    {
        Zankitext.text = "×" + playermanager[Ownmachine_Inform.ownmachine].GetLifeStock().ToString();
    }
}
