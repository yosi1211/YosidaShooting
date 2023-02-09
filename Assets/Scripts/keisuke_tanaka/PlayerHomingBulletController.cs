using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingBulletController : MonoBehaviour
{
    [SerializeField, Header("�_���[�W")]
    int damage = 10;
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    PlayerBulletPoolController objectPool;
    public float speed;
    private GameObject target;
    Vector3 targetVec;

    public void Init(GameObject gameObject)
    {
        target = gameObject;
    }
    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<PlayerBulletPoolController>();
        gameObject.SetActive(false);

        targetVec = target.transform.position;
    }

    void Update()
    {
        //�Ώە��ւ̃x�N�g���Z�o
        Vector3 toDirection = target.transform.position - transform.position;
        //�Ώە�����]����
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

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
            collision.gameObject.GetComponent<EnemyManager>().EnemyHPManager(damage);
            objectPool.Collect(this);
        }
        if (collision.gameObject.tag == "EnemyMob")
        {
            objectPool.Collect(this);
        }
    }

    public void ShowInStage(Vector3 _pos/*, Quaternion rot*/)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
        //transform.rotation = rot;
    }

    public void HideFromStage()
    {
        //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
        objectPool.Collect(this);
    }

}
