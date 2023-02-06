using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchL
{
    public class ObjectPoolControler_SearchL : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        List<BulletController_SearchL> _SearchL;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_SearchL bullet;
        [SerializeField] Transform bulletPrefab;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_SearchL> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int density = 10;
        int z = 0;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController_SearchL>();
            _SearchL = new List<BulletController_SearchL>();
            listCount = _SearchL.Count;
            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_SearchL tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                tmpBullet.Init(player);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_SearchL Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_SearchL tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            _SearchL.Add(tmpBullet);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.left;
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_SearchL _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
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