using UnityEngine;
using PoolControler_SearchL;

public class BulletController_SearchL : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolControler_SearchL objectPool;
    public float speed;//速度
    GameObject target;//狙う対象
    Vector2 targetVec;//狙う対象の位置
    bool check = true;//離れているかの確認用
    [SerializeField,Header("弾")]
    GameObject Bullet;
    [SerializeField,Header("追尾範囲")]
    float distance;

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolControler_SearchL>();
        gameObject.SetActive(false);
        //狙う対象を名前で取得
        target = GameObject.Find("Player");
    }
    void Update()
    {
        targetVec = target.transform.position;
        //弾と狙う対象の距離を取得、格納
        float dist = Vector2.Distance(targetVec,transform.position);
        Quaternion angle = transform.rotation;
        if (check)
        {
            if (dist >= distance)
            {
                //対象物へのベクトル算出
                Vector2 toDirection = target.transform.position - transform.position;
                //対象物を回転する
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
        //下の回収処理を呼び出す
        HideFromStage();
    }


    public void ShowInStage(Vector3 _pos)
    {
        //positionを渡された座標に設定
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
        check = true;
    }
}
