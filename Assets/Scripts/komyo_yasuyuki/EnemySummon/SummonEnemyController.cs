using UnityEngine;
using PoolControler_Summon;

public class SummonEnemyController : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolController_Summon objectPool;
    public float speed;
    [SerializeField]
    private int HP;

    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolController_Summon>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        HideFromStage();
    }

    public void ShowInStage(Vector3 _pos)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        if (HP <= 0)
        {
            //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
            objectPool.Collect(this);
        }
    }
}