using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Option
{
    public class ObjectPoolController_Option : MonoBehaviour
    {
        //リストの取得
        List<SummonOptionController> _SummonL;
        int listCount = 0;
        //召喚する敵のプレハブ
        [SerializeField] SummonOptionController bullet;
        //生成する数
        int maxCount = 2;
        //生成した敵を格納するQueue
        Queue<SummonOptionController> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        //配置パターン用
        int count = 1;
        float _left = -1;
        Vector3 left;
        float _right = 1;
        Vector3 right;
        float _down = -1;
        Vector3 down;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<SummonOptionController>();
            //リストの初期化
            _SummonL = new List<SummonOptionController>();
            listCount = _SummonL.Count;
            //敵を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                SummonOptionController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }
        //貸し出す処理
        public SummonOptionController Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから敵を一つ取り出す
            SummonOptionController tmpBullet = bulletQueue.Dequeue();
            //敵を表示する
            tmpBullet.gameObject.SetActive(true);
            //リストに格納
            _SummonL.Add(tmpBullet);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos);
            switch (count)
            {
                case 1:
                    right.x = _right;
                    tmpBullet.transform.position += right;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 2:
                    left.x = _left;
                    tmpBullet.transform.position += left;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count = 1;
                    break;
                default:
                    Debug.Log("switch default");
                    break;
            }
            //呼び出し元に渡す
            return tmpBullet;
        }
        //弾の回収処理
        public void Collect(SummonOptionController _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
        void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SummonL[i]);
            }
            _SummonL.Clear();
        }
    }
}