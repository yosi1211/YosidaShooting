using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerBulletLauncher : MonoBehaviour
{
    CompositeDisposable disposable = new();
    //オブジェクトプール
    [SerializeField] PlayerBulletPoolController objectPool;
    //発射の間隔
    [SerializeField] float interval;

    private int deleyCount = 0; 
    void Start()
    {
        
    }
    void _shot()
    {
        objectPool.Launch(transform.position);
    }
    void OnDestroy()
    {
        disposable.Dispose();
    }
    void Update()
    {
        if(deleyCount == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _shot();
                deleyCount = 250;
            }
        }
        if (deleyCount != 0)
        {
            deleyCount--;
        }
    }
}
