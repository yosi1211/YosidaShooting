using UnityEngine;
using PoolControler_Mobs;

public class BulletController_Mobs : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolController_Mobs objectPool;
    public float speed;//���x

    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolController_Mobs>();
        gameObject.SetActive(false);

    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //���̉���������Ăяo��
        HideFromStage();
    }


    public void ShowInStage(Vector3 _pos,Quaternion _rot)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
        transform.rotation = _rot;
    }

    public void HideFromStage()
    {
        //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
        objectPool.Collect(this);
    }
}