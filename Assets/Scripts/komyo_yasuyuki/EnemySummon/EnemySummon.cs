using UnityEngine;
using PoolControler_Summon;
using UniRx;
using Other_Script;

public class EnemySummon : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1回で撃つ上限
    Subject<int> shotCount = new(); //撃った回数
    CompositeDisposable disposable = new();
    //オブジェクトプール
    [SerializeField] ObjectPoolController_Summon objectPool;
    //発射の間隔
    [SerializeField] float interval;
    private TimerModel timerModel = new();

    void Start()
    {
    }
    void _shot()
    {
        shotCount.DistinctUntilChanged()
                .Where(x => x < Limit)
            .Subscribe(x =>
            {
                for (int i = 0; i < 4;i++)
                {
                    objectPool.Launch(transform.position);
                }
                timerModel.EndTimer();
                timerModel = new();
                timerModel.GetEndTimer()
                .Subscribe(_ =>
                {
                    shotCount.OnNext(x + 1);
                });
                timerModel.SetTimer(interval);
            }).AddTo(disposable);
        shotCount.OnNext(0);
    }
    void OnDestroy()
    {
        disposable.Dispose();
    }
    public void SetLimit(int _Limit)
    {
        disposable.Clear();
        shotLimit.Subscribe(x =>
        {
            Limit = x;
            _shot();
        }).AddTo(disposable);
        shotLimit.OnNext(_Limit);
    }
    //テスト用
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetLimit(10);
        }
    }
}