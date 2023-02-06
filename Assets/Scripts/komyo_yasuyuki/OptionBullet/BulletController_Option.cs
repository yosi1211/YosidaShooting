using UnityEngine;
using PoolControler_OptionB;

public class BulletController_Option : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolController_OptionBullet objectPool;
    public float speed;//速度

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolController_OptionBullet>();
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //下の回収処理を呼び出す
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
        //positionを渡された座標に設定
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }
}

