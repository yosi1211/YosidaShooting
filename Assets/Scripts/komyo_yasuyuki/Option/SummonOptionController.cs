using UnityEngine;
using PoolControler_Option;

public class SummonOptionController : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolController_Option objectPool;

    [SerializeField,Header("制限速度")]
    private float limitSpeed;
    [SerializeField]
    private float optionspeed;
    //コンポーネント取得
    private Rigidbody2D rb;
    private Transform playertrans;
    private Transform mytrans;
    GameObject Player;
    //くっつかないよう
    float distance = 1;
    Vector2 playerVec;
    public void Init(GameObject gameObject)
    {
        Player = gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerのトランスフォームを取得
        
        mytrans = GetComponent<Transform>();
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolController_Option>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        //プレイヤーのVector3,transformを取得
        playerVec = Player.transform.position;
        playertrans = Player.transform.transform;
        //くっつかないよう
        float dist = Vector2.Distance(playerVec, transform.position);
        if (dist >= distance)
        {
            //弾から追いかける対象への方向を計算
            Vector2 vector2 = playertrans.position - mytrans.position;
            //方向の長さを1に正規化、力をAddForceで加える
            rb.AddForce(vector2.normalized * optionspeed);
            //速度制限
            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed);
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);
            rb.velocity = new Vector2(speedXTemp, speedYTemp);
        }
        HideFromStage();
    }

    /*private void OnBecameInvisible()
    {
        //下の回収処理を呼び出す(こいつの場合HPがあれな時的な関数だと思う)
        HideFromStage();
    }*/


    public void ShowInStage(Vector3 _pos)
    {
        //positionを渡された座標に設定
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