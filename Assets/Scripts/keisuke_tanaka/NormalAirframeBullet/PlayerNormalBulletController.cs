using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalBulletController : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    PlayerNormalBulletPoolController objectPool;
    public float speed;

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<PlayerNormalBulletPoolController>();
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
    public void ShowInStage(Vector3 _pos/*, Quaternion rot*/)
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
