using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Option
{
    public class ObjectPoolController_Option : MonoBehaviour
    {
        //リストの取得
        List<SummonOptionController> _SummonOL;
        int listCount = 0;
        //召喚する敵のプレハブ
        [SerializeField] SummonOptionController option;
        //生成する数
        int maxCount = 2;
        //生成した敵を格納するQueue
        Queue<SummonOptionController> optionQueue;
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
            optionQueue = new Queue<SummonOptionController>();
            //リストの初期化
            _SummonOL = new List<SummonOptionController>();
            listCount = _SummonOL.Count;
            //オプションを生成
            for (int i = 0; i < maxCount; i++)
            {
                //生成
                SummonOptionController tmpOption = Instantiate(option, setPos, setRot, transform);
                //Queueに追加
                optionQueue.Enqueue(tmpOption);
            }
        }
        //貸し出す処理
        public SummonOptionController Launch(Vector3 _pos)
        {
            //Queueが空ならnull
            if (optionQueue.Count <= 0) return null;
            //Queueから一つ取り出す
            SummonOptionController tmpOption = optionQueue.Dequeue();
            //表示する
            tmpOption.gameObject.SetActive(true);
            //リストに格納
            _SummonOL.Add(tmpOption);
            //渡された座標に移動する
            tmpOption.ShowInStage(_pos);
            switch (count)
            {
                case 1:
                    right.x = _right;
                    tmpOption.transform.position += right;
                    down.y = _down;
                    tmpOption.transform.position += down;
                    count++;
                    break;
                case 2:
                    left.x = _left;
                    tmpOption.transform.position += left;
                    down.y = _down;
                    tmpOption.transform.position += down;
                    count = 1;
                    break;
                default:
                    Debug.Log("switch default");
                    break;
            }
            //呼び出し元に渡す
            return tmpOption;
        }
        //回収処理
        public void Collect(SummonOptionController _bullet)
        {
            //ゲームオブジェクトを非表示
            _bullet.gameObject.SetActive(false);
            //Queueに格納
            optionQueue.Enqueue(_bullet);
        }
        void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SummonOL[i]);
            }
            _SummonOL.Clear();
        }
    }
}