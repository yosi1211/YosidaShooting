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
    PlayerManager life;
    // Start is called before the first frame update
    void Start()
    {
        Zankitext = Zankitext.GetComponent<TextMeshProUGUI>();
        life = life.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Zankitext.text = life.GetLifeStock().ToString();
    }
}
