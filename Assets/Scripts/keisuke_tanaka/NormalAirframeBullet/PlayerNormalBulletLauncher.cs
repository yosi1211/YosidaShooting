using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;

public class PlayerNormalBulletLauncher : MonoBehaviour
{
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] PlayerNormalBulletPoolController objectPool;
    //���˂̊Ԋu
    [SerializeField] int interval = 100;

    private float count = 0;
    bool isPressed;

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
        if (isPressed)
        {
            Debug.Log("�����ꂽ");
            if (count % interval == 0)
            {
                count = 0;
                _shot();
            }
            count++;
        }
        else
        {
            count = 0;
        }
    }
    public void InputBullet(InputAction.CallbackContext context)
    {
        isPressed = Keyboard.current.spaceKey.IsPressed();
    }

}
