using UnityEngine;
using PoolControler_Search;
using UniRx;
using Other_Script;
public class Launcher_Search : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1��Ō����
    Subject<int> shotCount = new(); //��������
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolControler_Search objectPool;
    //���˂̊Ԋu
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
                objectPool.Launch(transform.position, transform.rotation);
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
    //�e�X�g�p
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetLimit(20);
        }
    }
}
