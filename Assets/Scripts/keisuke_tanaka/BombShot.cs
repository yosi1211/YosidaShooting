using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_360;
using PoolControler_Fire;
using PoolControler_Twin;
using PoolControler_SearchL;
using PoolControler_SearchR;
using PoolControler_Summon;

public class BombShot : MonoBehaviour
{
    [SerializeField] ObjectPoolControler_360 enemybullet360;
    [SerializeField] ObjectPoolControler_Fire enemybulletFire;
    [SerializeField] ObjectPoolControler_Twin enemybulletTwin;
    [SerializeField] ObjectPoolControler_SearchL enemybulletSearchL;
    [SerializeField] ObjectPoolControler_SearchR enemybulletSearchR;
    [SerializeField] ObjectPoolController_Summon enemybulletSummon;

    [SerializeField] private Vector3 force = new Vector3(0,0.5f,0);
    [SerializeField] Rigidbody2D rb;
    //ボムの位置座標
    Vector3 Bombtransform = new Vector3(0,0,0.2f);
    //爆発する位置
    [SerializeField] Vector3 explosePosition;
    [SerializeField] private GameObject targetObject;
    private Vector3 changesizespeed = new Vector3(2, 2, 0);
    private int ButtonFlag = 1;

    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Bombtransform == explosePosition)
        {
            enemybullet360.CollectList();
            enemybulletFire.CollectList();
            enemybulletTwin.CollectList();
            enemybulletSearchL.CollectList();
            enemybulletSearchR.CollectList();
            enemybulletSummon.CollectList();
            targetObject.transform.localScale += changesizespeed * Time.deltaTime;
        }
        else
        {
            shot();
        }
        if(targetObject.transform.localScale.x > 3.5)
        {
            targetObject.SetActive(false);
        }
    }
    public void shot()
    {
        transform.Translate(0, 0.1f, 0.2f);
    }
    public void InitPos(Vector3 pos)
    {
        explosePosition = pos;
    }
}
