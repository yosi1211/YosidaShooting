using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerNormalBulletLauncher : MonoBehaviour
{
    CompositeDisposable disposable = new();
    //オブジェクトプール
    [SerializeField] PlayerNormalBulletPoolController objectPool;
    //発射の間隔
    [SerializeField] float interval;

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
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _shot();
        }
    }

}
