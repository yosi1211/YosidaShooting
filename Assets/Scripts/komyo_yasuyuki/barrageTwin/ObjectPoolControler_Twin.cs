using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Twin
{
    public class ObjectPoolControler_Twin : MonoBehaviour
    {
        //���X�g�̎擾
        List<BulletController_Twin> _TwinL;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_Twin bullet;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_Twin> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        [SerializeField, Header("��{�̌���(1~0.1���炢)")]
        float space = 0f;
        float x = 0;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController_Twin>();
            //���X�g�̏�����
            _TwinL = new List<BulletController_Twin>();
            listCount = _TwinL.Count;

            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_Twin tmpBullet = Instantiate(bullet, setPos, Quaternion.identity, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_Twin Launch(Vector3 _pos, Quaternion rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_Twin tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //�Ԃ�������
            if (x == 0)
            {
                x = 0;
                x -= space * 2;
            }
            else
            {
                x = -x;
            }
            _pos.x += x;
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos, rot);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_Twin _bullet)
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
                Collect(_TwinL[i]);
            }
            _TwinL.Clear();
        }
        //public int Getspace()
        //{
        //  return space;
        //}
    }
}