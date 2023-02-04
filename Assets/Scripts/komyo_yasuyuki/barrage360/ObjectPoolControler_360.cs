using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_360
{
    public class ObjectPoolControler_360 : MonoBehaviour
    {
        //���X�g�̎擾
        List<BulletController_360> _360L;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_360 bullet;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_360> bulletQueue;
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
            bulletQueue = new Queue<BulletController_360>();
            //���X�g�̏�����
            _360L = new List<BulletController_360>();
            listCount = _360L.Count;

            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_360 tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_360 Launch(Vector3 _pos, Quaternion rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_360 tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            _360L.Add(tmpBullet);
            //��]������
            z += density;
            rot = Quaternion.AngleAxis(z, Vector3.forward);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos, rot);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_360 _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        public int Getdensity() {
            return density;
        }
        void CollectList() {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_360L[i]);
            }
            _360L.Clear();
        }
    }
}