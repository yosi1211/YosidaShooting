using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Twin
{
    public class ObjectPoolControler_Twin : MonoBehaviour
    {
        //リストの取得
        List<BulletController_Twin> _TwinL;
        int listCount = 0;
        //弾のプレハブ
        [SerializeField] BulletController_Twin bullet;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_Twin> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        [SerializeField, Header("二本の隙間(1~0.1ぐらい)")]
        float space = 0f;
        float x = 0;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_Twin>();
            //リストの初期化
            _TwinL = new List<BulletController_Twin>();
            listCount = _TwinL.Count;

            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                BulletController_Twin tmpBullet = Instantiate(bullet, setPos, Quaternion.identity, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //弾を貸し出す処理
        public BulletController_Twin Launch(Vector3 _pos, Quaternion rot)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_Twin tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //間をあける
            if (x == 0)
            {
                x = 0;
                x -= space * 2;
            }
            else
            {
                x = -x;
            }
            _pos.x += x;
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos, rot);
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_Twin _bullet)
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
                Collect(_TwinL[i]);
            }
            _TwinL.Clear();
        }
        //public int Getspace()
        //{
        //  return space;
        //}
    }
}