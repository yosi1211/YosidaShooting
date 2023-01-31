using UnityEngine;
using PoolControler_Search;

public class BulletController_Search : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolControler_Search objectPool;
    public float speed;
    GameObject target;
    Vector3 targetVec;


    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolControler_Search>();
        gameObject.SetActive(false);
        target = GameObject.Find("Player");
        targetVec = target.transform.position;
    }
    void Update()
    {
        //float dist = Vector3.Distance(targetVec,transform.position);
        //if (dist >= 1)
        //{
            //対象物へのベクトル算出
            Vector3 toDirection = target.transform.position - transform.position;
            //対象物を回転する
            transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
        //}
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
    }
}
