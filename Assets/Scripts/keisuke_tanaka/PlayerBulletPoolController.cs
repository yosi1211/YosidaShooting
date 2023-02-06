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
    //�e�̃v���n�u
    [SerializeField] PlayerHomingBulletController bullet;
    //�������鐔
    [SerializeField] int maxCount;
    //���������e���i�[����Queue
    Queue<PlayerHomingBulletController> bulletQueue;
    //���񐶐����̃|�W�V����
    Vector3 setPos = new Vector3(100, 100, 0);
    Quaternion setRot = Quaternion.identity;
    [SerializeField, Header("���x")]
    int density = 0;
    int z = 0;
    int count = 0;
    //PlayerBulletController bulletController;
    //�N�����̏���
    private void Awake()
    {
        //Queue�̏�����
        bulletQueue = new Queue<PlayerHomingBulletController>();

        //�e�𐶐����郋�[�v
        for (int i = 0; i < maxCount; i++)
        {
            //����
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
            //Queue�ɒǉ�
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
        //Queue�ɒǉ�
        bulletQueue.Enqueue(tmpBullet);

    }
    //�e��݂��o������
    public PlayerHomingBulletController Launch(Vector3 _pos)//, Quaternion rot)
    {
        //Queue����Ȃ�null
        if (bulletQueue.Count <= 0) return null;
        //Queue����e������o��
        PlayerHomingBulletController tmpBullet = bulletQueue.Dequeue();
        //�e��\������
        tmpBullet.gameObject.SetActive(true);
        //�n���ꂽ���W�ɒe���ړ�����
        tmpBullet.ShowInStage(_pos/*,rot*/);
        //�Ăяo�����ɓn��
        return tmpBullet;
    }

    //�e�̉������
    public void Collect(PlayerHomingBulletController _bullet)
    {
        //�e�̃Q�[���I�u�W�F�N�g���\��
        _bullet.gameObject.SetActive(false);
        //Queue�Ɋi�[
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
