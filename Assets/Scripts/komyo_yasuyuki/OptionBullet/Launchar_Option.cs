using UnityEngine;
using PoolControler_OptionB;
using UniRx;
using Other_Script;
public class Launchar_Option : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1回で出す上限
    Subject<int> shotCount = new(); //出した回数
    CompositeDisposable disposable = new();
    //オブジェクトプール
    [SerializeField] ObjectPoolController_OptionBullet objectPool;
    //出現の間隔
    [SerializeField] float interval;
    private TimerModel timerModel = new();
    void _shot()
    {
        shotCount.DistinctUntilChanged()
                .Where(x => x < Limit)
            .Subscribe(x =>
            {
                objectPool.Launch(transform.position);
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
    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space/*ここをplayerの攻撃と同じに*/))
        {
            SetLimit(1);
        }
    }
}