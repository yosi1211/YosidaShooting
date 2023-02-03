using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using PoolControler_360;

public class ChangeBombScaleSize : MonoBehaviour
{
    [SerializeField] ObjectPoolControler_360 enemybullet;
    //[SerializeField] BulletController_360 enemybullet;
    [SerializeField] private GameObject targetObject;
    private Vector3 changesizespeed = new Vector3(2,2,0);
    Vector3 initpos;
    void Start()
    {
        targetObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject == true)
        {
            ChangeScale();
        }
    }
    public void ChangeScale() 
    {
        targetObject.SetActive(true);
        targetObject.transform.localScale += changesizespeed * Time.deltaTime;
        enemybullet.CollectList();
        if(targetObject.transform.localScale.x > 2.5)
        {
            targetObject.SetActive(false);
            targetObject.transform.localScale = initpos;
        }

    }
}
