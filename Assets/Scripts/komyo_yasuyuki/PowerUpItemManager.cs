using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_Summon;

public class PowerUpItemManager : MonoBehaviour
{
    [SerializeField]
    ObjectPoolController_Summon parentdate;
    [SerializeField]
    GameObject PItem;
    bool check = false;
    bool call = true;

    private void Start()
    {
        PItem.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //ランダムな親オブジェクトに
        GameObject root = PItem.transform.parent.gameObject;
        if (root.activeSelf)
        {
            if (call)
            {
                PItem.transform.position = root.transform.position;
            }
        }
        else{
            //親オブジェクト解除
            PItem.transform.parent = null;
            //このscriptがアタッチされているオブジェクトの子供に
            PItem.transform.parent = transform.gameObject.transform;
            check = true;
        }
        if (check)
        {
            //表示
            PItem.SetActive(true);
        }
    }
}
