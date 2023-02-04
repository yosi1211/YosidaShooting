using UnityEngine;
using PoolControler_Summon;
using UniRx;
using Other_Script;

public class EnemySummon : MonoBehaviour
{
    int Limit;
    Subject<int> shotLimit = new(); //1��Ō����
    Subject<int> shotCount = new(); //��������
    CompositeDisposable disposable = new();
    //�I�u�W�F�N�g�v�[��
    [SerializeField] ObjectPoolController_Summon objectPool;
    //���˂̊Ԋu
    [SerializeField] float interval;
    private TimerModel timerModel = new();
    //powerUP�A�C�e���̐���
    [SerializeField, Header("�K�L")]
    private GameObject PItem;
    void _shot()
    {
        shotCount.DistinctUntilChanged()
                .Where(x => x < Limit)
            .Subscribe(x =>
            {
                int rand = Random.Range(0,4);
                for (int i = 0; i < 4;i++)
                {
                    objectPool.Launch(transform.position);
                    if (i == rand) {
                        PItem.transform.parent
                            = objectPool.transform.GetChild(i);
                        PItem.transform.position = objectPool.transform.localPosition;
                    }
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetLimit(1);
        }
    }
}