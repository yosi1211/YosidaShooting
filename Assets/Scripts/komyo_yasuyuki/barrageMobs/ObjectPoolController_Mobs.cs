using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Mobs
{
    public class ObjectPoolController_Mobs : MonoBehaviour
    {
        //リストの取得
        List<BulletController_Mobs> _MobsL;
        int listCount = 0;
        //弾のプレハブ
        [SerializeField] BulletController_Mobs bullet;
        [SerializeField] Transform bulletPrefab;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_Mobs> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int z = 0;
        //プレイヤー追尾用
        GameObject target;
        //Vector2 targetVec;
        //起動時の処理
        public void Init(GameObject gameObject) {
            target = gameObject;
        }
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_Mobs>();
            //リストの初期化
            _MobsL = new List<BulletController_Mobs>();
            listCount = _MobsL.Count;

            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                BulletController_Mobs tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //弾を貸し出す処理
        public BulletController_Mobs Launch(Vector3 _pos,Quaternion _rot)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_Mobs tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //リストに格納
            _MobsL.Add(tmpBullet);
            //対象物へのベクトル算出
            Vector2 toDirection = target.transform.position - transform.position;
            //対象物を回転する
            _rot = Quaternion.FromToRotation(Vector2.up, toDirection);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos,_rot);
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_Mobs _bullet)
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
                Collect(_MobsL[i]);
            }
            _MobsL.Clear();
        }
    }
}
