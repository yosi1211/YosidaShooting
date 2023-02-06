using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    
    private SpriteRenderer enemyimg;
    [SerializeField,Header("ìGÇÃÉXÉsÅ[Éh")]
    private float speed = 5f;
    [SerializeField,Header("ìGÇÃHP")]
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

    [SerializeField] Launcher_360 launcher360;
    [SerializeField] Launcher_Fire launcherFire;
    [SerializeField] Launcher_Twin launcherTwin;
    [SerializeField] Launcher_SearchL launcherSearchL;
    [SerializeField] Launcher_SearchR launcherSearchR;
    [SerializeField] EnemySummon enemy_summon;

    private float randomValue;

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
    void Update()
    {
        randomValue = UnityEngine.Random.Range(1, 6);
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
                RandomMove();
            })
            .AddTo(update);
        moveCount.Where(x => x == 2)
            .Subscribe(_ => {
                tempUpdate.Dispose();
                //moveEnd.OnNext(true);
                Move(InitPos);
                RandomMove();
            })
            .AddTo(update);
        moveCount.Where(x => x == 3)
            .Subscribe(_ =>
            {
                //moveEnd.OnNext(true);
                tempUpdate.Dispose();
                count = 0;
                if (EnemyHP < 80){
                    speed = 7f;
                }
                if (EnemyHP < 50){
                    speed = 9f;
                }
                if (EnemyHP < 20){
                    speed = 11f;
                }
                Move(targetPos);
                RandomMove();
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
    private void RandomMove()
    {
        Debug.Log(randomValue);
        switch (randomValue)
        {
            case 1:
                launcher360.SetLimit(1);
                break;
            case 2:
                launcherFire.SetLimit(1);
                break;
            case 3:
                launcherTwin.SetLimit(1);
                break;
            case 4:
                launcherSearchL.SetLimit(1);
                break;
            case 5:
                launcherSearchR.SetLimit(1);
                break;
            case 6:
                enemy_summon.SetLimit(1);
                break;
        }
    }
    private void OnDestroy()
    {
        update.Dispose();
    }
}
