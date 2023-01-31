using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolController : MonoBehaviour
{
    //弾のプレハブ
    [SerializeField] PlayerHomingBulletController bullet;
    //生成する数
    [SerializeField] int maxCount;
    //生成した弾を格納するQueue
    Queue<PlayerHomingBulletController> bulletQueue;
    //初回生成時のポジション
    Vector3 setPos = new Vector3(100, 100, 0);
    Quaternion setRot = Quaternion.identity;
    [SerializeField, Header("密度")]
    int density = 0;
    int z = 0;
    //PlayerBulletController bulletController;
    //起動時の処理
    private void Awake()
    {
        //Queueの初期化
        bulletQueue = new Queue<PlayerHomingBulletController>();

        //弾を生成するループ
        for (int i = 0; i < maxCount; i++)
        {
            //生成
            PlayerHomingBulletController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
            //Queueに追加
            bulletQueue.Enqueue(tmpBullet);
        }
    }


    //弾を貸し出す処理
    public PlayerHomingBulletController Launch(Vector3 _pos)//, Quaternion rot)
    {
        //Queueが空ならnull
        if (bulletQueue.Count <= 0) return null;
        //Queueから弾を一つ取り出す
        PlayerHomingBulletController tmpBullet = bulletQueue.Dequeue();
        //弾を表示する
        tmpBullet.gameObject.SetActive(true);
        //渡された座標に弾を移動する
        tmpBullet.ShowInStage(_pos/*,rot*/);
        //呼び出し元に渡す
        return tmpBullet;
    }

    //弾の回収処理
    public void Collect(PlayerHomingBulletController _bullet)
    {
        //弾のゲームオブジェクトを非表示
        _bullet.gameObject.SetActive(false);
        //Queueに格納
        bulletQueue.Enqueue(_bullet);
    }
    
    public int Getdensity()
    {
        return density;
    }
}
