using UnityEngine;
using PoolControler_OptionB;
using UniRx;
using Other_Script;
public class Launchar_Option : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1��ŏo�����
    Subject<int> shotCount = new(); //�o������
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolController_OptionBullet objectPool;
    //�o���̊Ԋu
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
        if (Input.GetKeyDown(KeyCode.Space/*������player�̍U���Ɠ�����*/))
        {
            SetLimit(1);
        }
    }
}