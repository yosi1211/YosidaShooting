using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int HP = 74;
    private Subject<int> moveCount = new Subject<int>();
    private int count = 0;
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    Vector3 movePos;
    private Vector3 InitPos;
    private Subject<bool> moveEnd = new Subject<bool> ();

    CompositeDisposable update = new CompositeDisposable();

    [SerializeField] Launcher_360 launcherFlag;

    IDisposable tempUpdate;
    public IObservable<bool> GetMoveEnd() { return moveEnd; }
    private void Awake()
    {
        InitPos = transform.position;
    }
    void Start()
    {
        MovePattern();
    }
    private void Move(Vector3 target)
    {
        tempUpdate = this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                if (transform.position == target)
                {
                    count++;
                    moveCount.OnNext(count);
                }
            });
    }
    public void MovePattern()
    {
        count = 0;
        moveCount.Where(x => x == 1)
            .Subscribe(_ => {
                tempUpdate.Dispose();
                Move(movePos);
                launcherFlag.SetLimit(1);
            })
            .AddTo(update);
        moveCount.Where(x => x == 2)
            .Subscribe(_ => {
                tempUpdate.Dispose();
                //moveEnd.OnNext(true);
                Move(InitPos);
                launcherFlag.SetLimit(1);
            })
            .AddTo(update);
        moveCount.Where(x => x == 3)
            .Subscribe(_ =>
            {
                //moveEnd.OnNext(true);
                tempUpdate.Dispose();
                count = 0;
                if (HP < 75){
                    speed = 10f;
                }
                if (HP < 50){
                    speed = 15f;
                }
                if(HP < 25){
                    speed = 20f;
                }
                Move(targetPos);
                launcherFlag.SetLimit(1);
            }).AddTo(update);
        Move(targetPos);
    }
    private void OnDestroy()
    {
        update.Dispose();
    }
}
