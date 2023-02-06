using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchR
{
    public class ObjectPoolControler_SearchR : MonoBehaviour
    {
        //playerの取得 
        [SerializeField]
        private GameObject player;
        //弾のプレハブ
        [SerializeField] BulletController_SearchR bullet;
        [SerializeField] Transform bulletPrefab;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_SearchR> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int z = 0;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_SearchR>();

            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                BulletController_SearchR tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                tmpBullet.Init(player);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //弾を貸し出す処理
        public BulletController_SearchR Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_SearchR tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.right;
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_SearchR _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
    }
}
