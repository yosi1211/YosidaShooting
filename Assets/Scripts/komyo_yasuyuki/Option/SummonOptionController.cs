using UnityEngine;
using PoolControler_Option;

public class SummonOptionController : MonoBehaviour
{
    //�I�u�W�F�N�g�v�[���p�R���g���[���[�i�[�p�ϐ��錾
    ObjectPoolController_Option objectPool;

    [SerializeField,Header("�������x")]
    private float limitSpeed;
    [SerializeField]
    private float optionspeed;
    //�R���|�[�l���g�擾
    private Rigidbody2D rb;
    private Transform playertrans;
    private Transform mytrans;
    GameObject Player;
    //�������Ȃ��悤
    float distance = 1;
    Vector2 playerVec;
    public void Init(GameObject gameObject)
    {
        Player = gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player�̃g�����X�t�H�[�����擾
        
        mytrans = GetComponent<Transform>();
        //�I�u�W�F�N�g�v�[�����擾
        objectPool = transform.parent.GetComponent<ObjectPoolController_Option>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        //�v���C���[��Vector3,transform���擾
        playerVec = Player.transform.position;
        playertrans = Player.transform.transform;
        //�������Ȃ��悤
        float dist = Vector2.Distance(playerVec, transform.position);
        if (dist >= distance)
        {
            //�e����ǂ�������Ώۂւ̕������v�Z
            Vector2 vector2 = playertrans.position - mytrans.position;
            //�����̒�����1�ɐ��K���A�͂�AddForce�ŉ�����
            rb.AddForce(vector2.normalized * optionspeed);
            //���x����
            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);
            rb.velocity = new Vector2(speedXTemp, speedYTemp);
        }
        HideFromStage();
    }

    /*private void OnBecameInvisible()
    {
        //���̉���������Ăяo��(�����̏ꍇHP������Ȏ��I�Ȋ֐����Ǝv��)
        HideFromStage();
    }*/


    public void ShowInStage(Vector3 _pos)
    {
        //position��n���ꂽ���W�ɐݒ�
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        if (!Player.activeSelf)
        {
            objectPool.Collect(this);
        }
    }
}