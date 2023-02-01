using UnityEngine;
using PoolControler_Mobs;

public class BulletController_Mobs : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolController_Mobs objectPool;
    public float speed;//速度

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolController_Mobs>();
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


    public void ShowInStage(Vector3 _pos,Quaternion _rot)
    {
        //positionを渡された座標に設定
        transform.position = _pos;
        transform.rotation = _rot;
    }

    public void HideFromStage()
    {
        //オブジェクトプールのCollect関数を呼び出し自身を回収
        objectPool.Collect(this);
    }
}