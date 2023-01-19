using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Search 
{
    public class ObjectPoolControler_Search : MonoBehaviour
    {
        //���@�_���p�̃I�u�W�F�N�g�擾
        [SerializeField] Transform Launcher;
        [SerializeField] Transform player;
        //�e�̃v���n�u
        [SerializeField] BulletController_Search bullet;
        [SerializeField] Transform bulletPrefab;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_Search> bulletQueue;
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
            bulletQueue = new Queue<BulletController_Search>();

            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_Search tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_Search Launch(Vector3 _pos, Quaternion rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_Search tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //��]������
            Vector3 dir = (player.position - bulletPrefab.position);
            rot = bulletPrefab.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos, rot);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_Search _bullet)
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