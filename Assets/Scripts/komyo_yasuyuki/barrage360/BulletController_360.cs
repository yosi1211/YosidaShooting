using UnityEngine;
using PoolControler_360;

public class BulletController_360 : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolControler_360 objectPool;
    public float speed;

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolControler_360>();
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


    public void ShowInStage(Vector3 _pos,Quaternion rot)
    {
        //positionを渡された座標に設定
        transform.position = _pos;
        transform.rotation = rot;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }
}