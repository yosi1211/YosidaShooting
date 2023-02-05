using UnityEngine;
using PoolControler_Summon;

public class SummonEnemyController : MonoBehaviour
{
    //オブジェクトプール用コントローラー格納用変数宣言
    ObjectPoolController_Summon objectPool;
    public float speed;
    [SerializeField]
    private int HP;

    void Start()
    {
        //オブジェクトプールを取得
        objectPool = transform.parent.GetComponent<ObjectPoolController_Summon>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        HideFromStage();
    }

    public void ShowInStage(Vector3 _pos)
    {
        //positionを渡された座標に設定
        transform.position = _pos;
    }

    public void HideFromStage()
    {
        if (HP <= 0)
        {
            //オブジェクトプールのCollect関数を呼び出し自身を回収
            objectPool.Collect(this);
        }
    }
}