using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchL
{
    public class ObjectPoolControler_SearchL : MonoBehaviour
    {
        [SerializeField] private List<GameObject> player;
        List<BulletController_SearchL> _SearchL;
        int listCount = 0;
        //弾のプレハブ
        [SerializeField] BulletController_SearchL bullet;
        [SerializeField] Transform bulletPrefab;
        //生成する数
        [SerializeField] int maxCount;
        //生成した弾を格納するQueue
        Queue<BulletController_SearchL> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int density = 10;
        int z = 0;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<BulletController_SearchL>();
            _SearchL = new List<BulletController_SearchL>();
            listCount = _SearchL.Count;
            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                if (Ownmachine_Inform.ownmachine == 0)
                {
                    //生成
                    BulletController_SearchL tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                    tmpBullet.Init(player[0]);
                    //Queueに追加
                    bulletQueue.Enqueue(tmpBullet);
                }
                if (Ownmachine_Inform.ownmachine == 1)
                {
                    //生成
                    BulletController_SearchL tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                    tmpBullet.Init(player[1]);
                    //Queueに追加
                    bulletQueue.Enqueue(tmpBullet);
                }
                if (Ownmachine_Inform.ownmachine == 2)
                {
                    //生成
                    BulletController_SearchL tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                    tmpBullet.Init(player[2]);
                    //Queueに追加
                    bulletQueue.Enqueue(tmpBullet);
                }
            }
        }


        //弾を貸し出す処理
        public BulletController_SearchL Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            BulletController_SearchL tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            _SearchL.Add(tmpBullet);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.left;
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(BulletController_SearchL _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            listCount = _SearchL.Count;
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SearchL[i]);
            }
            _SearchL.Clear();
        }
        public int Getdensity()
        {
            return density;
        }
    }
}