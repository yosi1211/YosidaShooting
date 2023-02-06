using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerNormalBulletLauncher : MonoBehaviour
{
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] PlayerNormalBulletPoolController objectPool;
    //���˂̊Ԋu
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
