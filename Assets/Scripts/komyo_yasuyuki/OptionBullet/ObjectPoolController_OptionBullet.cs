using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_OptionB
{
    public class ObjectPoolController_OptionBullet : MonoBehaviour
    {
        //リストの取得
        List<BulletController_Option> OptionBL;
        int listCount = 0;
        //弾のプレハブ
        [SerializeField] BulletController_Option bullet;
        [SerializeField] Transform bulletPrefab;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_Option> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int z = 0;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_Option>();
            //リストの初期化
            OptionBL = new List<BulletController_Option>();
            listCount = OptionBL.Count;
            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                BulletController_Option tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
                gameObject.transform.parent = null;
            }
        }


        //弾を貸し出す処理
        public BulletController_Option Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_Option tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //リストに格納
            OptionBL.Add(tmpBullet);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos);
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_Option _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(OptionBL[i]);
            }
            OptionBL.Clear();
        }
    }
}
