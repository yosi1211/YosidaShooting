using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_SearchR
{
    public class ObjectPoolControler_SearchR : MonoBehaviour
    {
        //Player�̎擾
        [SerializeField] private GameObject player;
        List<BulletController_SearchR> _SearchR;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_SearchR bullet;
        [SerializeField] Transform bulletPrefab;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_SearchR> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int density = 10;
        int z = 0;

        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController_SearchR>();
            _SearchR = new List<BulletController_SearchR>();
            listCount = _SearchR.Count;
            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_SearchR tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                tmpBullet.Init(player);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_SearchR Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_SearchR tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            _SearchR.Add(tmpBullet);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos);
            tmpBullet.transform.position += Vector3.right;
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_SearchR _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            listCount = _SearchR.Count;
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SearchR[i]);
            }
            _SearchR.Clear();
        }
        public int Getdensity()
        {
            return density;
        }

    }
}
