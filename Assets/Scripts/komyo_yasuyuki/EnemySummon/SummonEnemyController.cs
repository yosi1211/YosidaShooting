using UnityEngine;
using PoolControler_Summon;

public class SummonEnemyController : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolController_Summon objectPool;
    public float speed;
    [SerializeField]
    private int HP;
    private int MaxHP;
    GameObject player;
    Vector3 pos;// = new Vector3(0,3,0);

    public void Init(GameObject gameObject)
    {
        player = gameObject;
    }

    void Start()
    {
        MaxHP = HP;
        pos = transform.position;
        pos = new Vector3(0,3,0);
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
        //_pos = pos;
        transform.position = _pos;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            HP -= 1;
            Debug.Log("Mob" + HP);
        }
        
        
    }
    public void HideFromStage()
    {
        if (HP <= 0)
        {
            //�I�u�W�F�N�g�v�[����Collect�֐����Ăяo�����g�����
            objectPool.Collect(this);
            objectPool.AddDeathCount();
            HP = MaxHP;
        }
    }
}