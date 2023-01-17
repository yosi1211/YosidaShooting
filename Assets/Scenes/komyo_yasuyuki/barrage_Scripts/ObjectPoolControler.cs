using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolControler
{
    public class ObjectPoolControler : MonoBehaviour
    {
        //�e�̃v���n�u
        [SerializeField] BulletController bullet;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        [SerializeField, Header("���x")]
        int density = 0;
        int z = 0;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController>();

            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController Launch(Vector3 _pos, Quaternion rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //��]������
            z += density;
            rot = Quaternion.AngleAxis(z, Vector3.forward);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos, rot);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        public int Getdensity() {
            return density;
        }
    }
}