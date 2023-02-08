using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using playermanager;

public class ZankiText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Zankitext;
    [SerializeField]
    PlayerManager horminglife;
    [SerializeField]
    PlayerManager normallife;
    [SerializeField]
    PlayerManager spreadlife;
    [SerializeField]
    GameObject hormingeir;
    [SerializeField]
    GameObject normaleir;
    [SerializeField]
    GameObject spreadeir;
    PlayerManager life;

    void Start()
    {
        Zankitext = Zankitext.GetComponent<TextMeshProUGUI>();
        if (hormingeir.activeSelf)
        {
            horminglife = horminglife.GetComponent<PlayerManager>();
            life = horminglife;
        }
        if (normaleir.activeSelf)
        {
            normallife = normallife.GetComponent<PlayerManager>();
            life = normallife;
        }
        if (spreadeir.activeSelf)
        {
            spreadlife = spreadlife.GetComponent<PlayerManager>();
            life = spreadlife;
        }
    }

    void Update()
    {
        Zankitext.text = life.GetLifeStock().ToString();
    }
}
