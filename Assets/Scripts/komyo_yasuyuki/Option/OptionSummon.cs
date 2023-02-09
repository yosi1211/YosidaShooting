using UnityEngine;
using PoolControler_Option;
using UniRx;
using Other_Script;

public class OptionSummon : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1��Ō����
    Subject<int> shotCount = new(); //��������
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolController_Option objectPool;
    //���˂̊Ԋu
    [SerializeField] float interval;
    private TimerModel timerModel = new();
    //powerUP�A�C�e���̐���
    [SerializeField, Header("�I�v�V����")]
    private GameObject Option;
    void _shot()
    {
        shotCount.DistinctUntilChanged()
                .Where(x => x < Limit)
            .Subscribe(x =>
            {
                for (int i = 0; i < 1; i++)
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
}
