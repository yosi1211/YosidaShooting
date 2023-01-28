using UnityEngine;
using PoolControler_SearchL;

public class BulletController_SearchL : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolControler_SearchL objectPool;
    public float speed;//���x
    GameObject target;//�_���Ώ�
    Vector2 targetVec;//�_���Ώۂ̈ʒu
    bool check = true;//����Ă��邩�̊m�F�p
    [SerializeField,Header("�e")]
    GameObject Bullet;
    [SerializeField,Header("�ǔ��͈�")]
    float distance;

    void Start()
    {
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolControler_SearchL>();
        gameObject.SetActive(false);
        //�_���Ώۂ𖼑O�Ŏ擾
        target = GameObject.Find("Player");
    }
    void Update()
    {
        targetVec = target.transform.position;
        //�e�Ƒ_���Ώۂ̋������擾�A�i�[
        float dist = Vector2.Distance(targetVec,transform.position);
        Quaternion angle = transform.rotation;
        if (check)
        {
            if (dist >= distance)
            {
                //�Ώە��ւ̃x�N�g���Z�o
                Vector2 toDirection = target.transform.position - transform.position;
                //�Ώە�����]����
                angle = Quaternion.FromToRotation(Vector2.up, toDirection);
                Bullet.transform.rotation = angle;
            }
            else {
                check = false;
            }
        }
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
        check = true;
    }
}
