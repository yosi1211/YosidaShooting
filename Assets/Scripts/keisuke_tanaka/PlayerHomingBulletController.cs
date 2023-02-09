using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingBulletController : MonoBehaviour
{
    [SerializeField, Header("ダメージ")]
    int damage = 10;
    //オブジェクトプール用コントローラー格納用変数宣言
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
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<PlayerBulletPoolController>();
        gameObject.SetActive(false);

        targetVec = target.transform.position;
    }

    void Update()
    {
        //対象物へのベクトル算出
        Vector3 toDirection = target.transform.position - transform.position;
        //対象物を回転する
        transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);

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
        //positionを渡された座標に設定
        transform.position = _pos;
        //transform.rotation = rot;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }

}
