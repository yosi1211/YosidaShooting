using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_360;

public class BombShot : MonoBehaviour
{
    [SerializeField] ObjectPoolControler_360 enemybullet;
    [SerializeField] private Vector3 force = new Vector3(0,0.5f,0);
    [SerializeField] Rigidbody2D rb;
    //ボムの位置座標
    Vector3 Bombtransform = new Vector3(0,0,0.2f);
    //爆発する位置
    [SerializeField] Vector3 explosePosition;
    [SerializeField] private GameObject targetObject;
    private Vector3 changesizespeed = new Vector3(2, 2, 0);

    // Start is called before the first frame update
    void Awake()
    {
        //targetObject.SetActive(false);
    }
    void Start()
    {
        //targetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Bombtransform == explosePosition)
        {
            enemybullet.CollectList();
            targetObject.transform.localScale += changesizespeed * Time.deltaTime;
        }
        else
        {
            shot();
        }
        if(targetObject.transform.localScale.x > 2.5)
        {
            targetObject.SetActive(false);
        }
    }
    public void shot()
    {
        transform.Translate(0, 0.1f, 0);
    }
    public void InitPos(Vector3 pos)
    {
        explosePosition = pos;
    }
}
