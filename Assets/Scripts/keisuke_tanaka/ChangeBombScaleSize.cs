using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ChangeBombScaleSize : MonoBehaviour
{
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
        if(targetObject.transform.localScale.x > 2.5)
        {
            targetObject.SetActive(false);
            targetObject.transform.localScale = initpos;
        }

    }
}
