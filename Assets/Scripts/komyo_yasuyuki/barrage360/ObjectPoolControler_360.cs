using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_360
{
    public class ObjectPoolControler_360 : MonoBehaviour
    {
        //リストの取得
        List<BulletController_360> _360L;
        int listCount = 0;
        //弾のプレハブ
        [SerializeField] BulletController_360 bullet;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_360> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        [SerializeField, Header("密度")]
        int density = 0;
        int z = 0;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_360>();
            //リストの初期化
            _360L = new List<BulletController_360>();
            listCount = _360L.Count;

            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                BulletController_360 tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //弾を貸し出す処理
        public BulletController_360 Launch(Vector3 _pos, Quaternion rot)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_360 tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //リストに格納
            _360L.Add(tmpBullet);
            //回転させる
            z += density;
            rot = Quaternion.AngleAxis(z, Vector3.forward);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos, rot);
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_360 _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
        public int Getdensity() {
            return density;
        }
        void CollectList() {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_360L[i]);
            }
            _360L.Clear();
        }
    }
}