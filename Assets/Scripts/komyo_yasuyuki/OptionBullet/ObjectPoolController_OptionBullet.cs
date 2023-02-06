using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_OptionB
{
    public class ObjectPoolController_OptionBullet : MonoBehaviour
    {
        //���X�g�̎擾
        List<BulletController_Option> OptionBL;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_Option bullet;
        [SerializeField] Transform bulletPrefab;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_Option> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int z = 0;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController_Option>();
            //���X�g�̏�����
            OptionBL = new List<BulletController_Option>();
            listCount = OptionBL.Count;
            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_Option tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
                gameObject.transform.parent = null;
            }
        }


        //�e��݂��o������
        public BulletController_Option Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_Option tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            OptionBL.Add(tmpBullet);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_Option _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(OptionBL[i]);
            }
            OptionBL.Clear();
        }
    }
}
