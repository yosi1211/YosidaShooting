using UnityEngine;
using PoolControler_Twin;
using UniRx;
using Other_Script;

public class Launcher_Twin : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1��Ō����
    Subject<int> shotCount = new(); //��������
    CompositeDisposable disposable = new();
    [SerializeField]
    GameObject enemy;
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolControler_Twin objectPool;
    //���˂̊Ԋu
    [SerializeField] float interval;
    private TimerModel timerModel = new();
    void _shot()
    {
        shotCount.DistinctUntilChanged()
                .Where(x => x < Limit)
            .Subscribe(x =>
            {
                for (int i = 0; i < 2; i++)
                {
                    objectPool.Launch(transform.position,transform.rotation);
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
    //�e�X�g�p
    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    SetLimit(3);
        //}
    }
}