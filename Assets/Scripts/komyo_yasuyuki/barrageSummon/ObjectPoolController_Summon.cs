using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Summon
{
    public class ObjectPoolController_Summon : MonoBehaviour
    {
        //召喚する敵のプレハブ
        [SerializeField] SummonEnemyController bullet;
        //生成する数
        int maxCount = 4;
        //生成した敵を格納するQueue
        Queue<SummonEnemyController> bulletQueue;
        //初回生成時のポジション
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        //配置パターン用
        int count = 1;
        [SerializeField]
        float _left;
        Vector3 left;
        [SerializeField]
        float _right;
        Vector3 right;
        [SerializeField]
        float _down;
        Vector3 down;
        [SerializeField]
        float _Maxidown;
        Vector3 Maxidown;
        //起動時の処理
        private void Awake()
        {
            //Queueの初期化
            bulletQueue = new Queue<SummonEnemyController>();

            //弾を生成するループ
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                SummonEnemyController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queueに追加
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //弾を貸し出す処理
        public SummonEnemyController Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (bulletQueue.Count <= 0) return null;
            //Queueから弾を一つ取り出す
            SummonEnemyController tmpBullet = bulletQueue.Dequeue();
            //弾を表示する
            tmpBullet.gameObject.SetActive(true);
            //渡された座標に弾を移動する
            tmpBullet.ShowInStage(_pos);
            switch (count) {
                case 1:
                    right.x = _right;
                    tmpBullet.transform.position += right;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 2:
                    right.x = _right*2;
                    tmpBullet.transform.position += right;
                    Maxidown.y = _Maxidown;
                    tmpBullet.transform.position += Maxidown;
                    count++;
                    break;
                case 3:
                    left.x = _left;
                    tmpBullet.transform.position += left;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 4:
                    left.x = _left*2;
                    tmpBullet.transform.position += left;
                    Maxidown.y = _Maxidown;
                    tmpBullet.transform.position += Maxidown;
                    break;
                default:
                    Debug.Log("えらってますよ間抜けが");
                    break;
            }
            //呼び出し元に渡す
            return tmpBullet;
        }

        //弾の回収処理
        public void Collect(SummonEnemyController _bullet)
        {
            //弾のゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            bulletQueue.Enqueue(_bullet);
        }
    }
}
