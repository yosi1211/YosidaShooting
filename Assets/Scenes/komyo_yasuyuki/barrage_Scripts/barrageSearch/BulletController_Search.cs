using UnityEngine;
using PoolControler_Search;

public class BulletController_Search : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolControler_Search objectPool;
    public float speed;
    GameObject target;
    Vector3 targetVec;


    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolControler_Search>();
        gameObject.SetActive(false);
        target = GameObject.Find("Player");
        targetVec = target.transform.position;
    }
    void Update()
    {
        //float dist = Vector3.Distance(targetVec,transform.position);
        //if (dist >= 1)
        //{
            //�Ώە��ւ̃x�N�g���Z�o
            Vector3 toDirection = target.transform.position - transform.position;
            //�Ώە�����]����
            transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
        //}
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //���̉���������Ăяo��
        HideFromStage();
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
