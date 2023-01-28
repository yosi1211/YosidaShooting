using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Fire { 
public class ObjectPoolControler_Fire : MonoBehaviour
{
    //�e�̃v���n�u
    [SerializeField] BulletController_Fire bullet;
    //�������鐔
    [SerializeField] int maxCount;
    //���������e���i�[����Queue
    Queue<BulletController_Fire> bulletQueue;
    //���񐶐����̃|�W�V����
    Vector3 setPos = new Vector3(100, 100, 0);
    Quaternion setRot = Quaternion.identity;
    int density = 10;
    int z = 155;
    //�N�����̏���
    private void Awake()
    {
        //Queue�̏�����
        bulletQueue = new Queue<BulletController_Fire>();

        //�e�𐶐����郋�[�v
        for (int i = 0; i < maxCount; i++)
        {
            //����
            BulletController_Fire tmpBullet = Instantiate(bullet, setPos, setRot, transform);
            //Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
        }
    }


        //�e��݂��o������
        public BulletController_Fire Launch(Vector3 _pos, Quaternion rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_Fire tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //��]������
            z += density;
            Debug.Log(z);
            rot = Quaternion.AngleAxis(z, Vector3.forward);
            if (z == 195)
            {
                z = 155;
            }
           // else if (z == 170) { 
             //   z = 180;
        //}
        //�n���ꂽ���W�ɒe���ړ�����
        tmpBullet.ShowInStage(_pos, rot);
        //�Ăяo�����ɓn��
        return tmpBullet;
    }

    //�e�̉������
    public void Collect(BulletController_Fire _bullet)
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
}
}
