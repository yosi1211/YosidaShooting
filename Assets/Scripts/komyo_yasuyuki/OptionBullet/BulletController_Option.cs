using UnityEngine;
using PoolControler_OptionB;

public class BulletController_Option : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolController_OptionBullet objectPool;
    public float speed;//���x

    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolController_OptionBullet>();
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            objectPool.Collect(this);
            collision.gameObject.GetComponent<EnemyManager>().EnemyHPManager(10);
        }
    }

    public void ShowInStage(Vector3 _pos)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
        objectPool.Collect(this);
    }
}

