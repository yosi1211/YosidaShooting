using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_Summon;

public class PlayerBulletPoolController : MonoBehaviour
{
    PlayerHomingBulletController tmpBullet;
    [SerializeField] ObjectPoolController_Summon summonPoolController;
    [SerializeField] private GameObject targetBossEnemy;
    [SerializeField] private GameObject targetMobEnemy1;
    [SerializeField] private GameObject targetMobEnemy2;
    [SerializeField] private GameObject targetMobEnemy3;
    [SerializeField] private GameObject targetMobEnemy4;
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
    int count = 0;
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
            tmpBullet = Instantiate(bullet, setPos, setRot, transform);
            if (summonPoolController.GetMobData() == 0)
            {
                Debug.Log("0if");
                tmpBullet.Init(targetBossEnemy);
            }
            //if (summonPoolController.GetMobData() == 4)
            //{
            //    Debug.Log("4if");
            //    tmpBullet.Init(targetMobEnemy);
            //}
            //if (summonPoolController.GetMobData() == 8)
            //{
            //    tmpBullet.Init(targetMobEnemy);
            //}
            //if (summonPoolController.GetMobData() == 12)
            //{
            //    tmpBullet.Init(targetMobEnemy);
            //}
            //Queueに追加
            bulletQueue.Enqueue(tmpBullet);
        }
    }

    void Update()
    {
        switch (summonPoolController.GetMobData())
        {
            case 1:
                tmpBullet.Init(targetMobEnemy1);
                break;
            case 2:
                tmpBullet.Init(targetMobEnemy2);
                break;
            case 3:
                tmpBullet.Init(targetMobEnemy3);
                break;
            case 4:
                tmpBullet.Init(targetMobEnemy4);
                break;
            case 5:
                tmpBullet.Init(targetBossEnemy);
                break;
            case 6:
                tmpBullet.Init(targetMobEnemy1);
                break;
            case 7:
                tmpBullet.Init(targetMobEnemy2);
                break;
            case 8:
                tmpBullet.Init(targetMobEnemy3);
                break;
            case 9:
                tmpBullet.Init(targetMobEnemy4);
                break;
            case 10:
                tmpBullet.Init(targetBossEnemy);
                break;
            case 11:
                tmpBullet.Init(targetMobEnemy1);
                break;
            case 12:
                tmpBullet.Init(targetMobEnemy2);
                break;
            case 13:
                tmpBullet.Init(targetMobEnemy3);
                break;
            case 14:
                tmpBullet.Init(targetMobEnemy4);
                break;
            case 15:
                tmpBullet.Init(targetBossEnemy);
                break;
            default:
                tmpBullet.Init(targetBossEnemy);
                break;
        }
        //Queueに追加
        bulletQueue.Enqueue(tmpBullet);

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
    public void AddObj(GameObject gameObj)
    {
        switch (count)
        {
            case 0:
                targetMobEnemy1 = gameObj;
                break;
            case 1:
                targetMobEnemy2 = gameObj;
                break;
            case 2:
                targetMobEnemy3 = gameObj;
                break;
            case 3:
                targetMobEnemy4 = gameObj;
                break;
        }
        count++;
    }
}
