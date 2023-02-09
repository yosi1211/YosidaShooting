using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.InputSystem;
public class PlayerBulletLauncher : MonoBehaviour
{
    CompositeDisposable disposable = new();
    //オブジェクトプール
    [SerializeField] PlayerBulletPoolController objectPool;
    //発射の間隔
    [SerializeField] int interval;
    private int deleyCount = 0;
    bool isPressed;
    bool PadIsPressed;
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
            if (PadIsPressed)
            {
                _shot();
                deleyCount = interval;
            }
        }
        if(deleyCount != 0)
        {
            deleyCount--;
        }
    }
    //void BulletCreate()
    //{
    //    if (deleyCount == 0)
    //    {
    //        //if (Input.GetKey(KeyCode.Space))
    //        //{
    //            _shot();
    //            deleyCount = interval;
    //        //}
    //    }
    //    if (deleyCount != 0)
    //    {
    //        deleyCount--;
    //    }
    //}
    public void InputBullet(InputAction.CallbackContext context)
    {
        //isPressed = Keyboard.current.spaceKey.IsPressed();
        PadIsPressed = Gamepad.current.buttonEast.IsPressed();
    }
}
