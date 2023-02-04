using UnityEngine;
using PoolControler_Twin;

public class BulletController_Twin : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolControler_Twin objectPool;
    public float speed;

    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolControler_Twin>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.position -= transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //���̉���������Ăяo��
        HideFromStage();
    }


    public void ShowInStage(Vector3 _pos,Quaternion rot)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
        transform.rotation = rot;
    }

    public void HideFromStage()
    {
        //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
        objectPool.Collect(this);
    }
}