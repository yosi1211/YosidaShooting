using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    
    public SpriteRenderer enemyimg;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int EnemyHP;
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
        enemyimg = GetComponent<SpriteRenderer>();
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
                if (EnemyHP < 80){
                    speed = 8f;
                }
                if (EnemyHP < 50){
                    speed = 10f;
                }
                if(EnemyHP < 20){
                    speed = 12f;
                }
                Move(targetPos);
                launcherFlag.SetLimit(1);
            }).AddTo(update);
        Move(targetPos);
    }
    public void EnemyHPManager(int attackPoint)
    {
        Debug.Log(EnemyHP);
        EnemyHP -= attackPoint;
        StartCoroutine(hitdamage());
        Debug.Log(EnemyHP + "//" + attackPoint);
    }
    private IEnumerator hitdamage()
    {
        enemyimg.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        enemyimg.color = Color.white;
    }
    private void OnDestroy()
    {
        update.Dispose();
    }
}
