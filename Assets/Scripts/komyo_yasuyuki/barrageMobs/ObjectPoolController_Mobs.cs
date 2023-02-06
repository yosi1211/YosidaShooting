using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Mobs
{
    public class ObjectPoolController_Mobs : MonoBehaviour
    {
        //���X�g�̎擾
        List<BulletController_Mobs> _MobsL;
        int listCount = 0;
        //�e�̃v���n�u
        [SerializeField] BulletController_Mobs bullet;
        [SerializeField] Transform bulletPrefab;
        //�������鐔
        [SerializeField] int maxCount;
        //���������e���i�[����Queue
        Queue<BulletController_Mobs> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        int z = 0;
        //�v���C���[�ǔ��p
        GameObject target;
        //Vector2 targetVec;
        //�N�����̏���
        public void Init(GameObject gameObject) {
            target = gameObject;
        }
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<BulletController_Mobs>();
            //���X�g�̏�����
            _MobsL = new List<BulletController_Mobs>();
            listCount = _MobsL.Count;

            //�e�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                BulletController_Mobs tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }


        //�e��݂��o������
        public BulletController_Mobs Launch(Vector3 _pos,Quaternion _rot)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����e������o��
            BulletController_Mobs tmpBullet = bulletQueue.Dequeue();
            //�e��\������
            tmpBullet.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            _MobsL.Add(tmpBullet);
            //�Ώە��ւ̃x�N�g���Z�o
            Vector2 toDirection = target.transform.position - transform.position;
            //�Ώە�����]����
            _rot = Quaternion.FromToRotation(Vector2.up, toDirection);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos,_rot);
            //�Ăяo�����ɓn��
            return tmpBullet;
        }

        //�e�̉������
        public void Collect(BulletController_Mobs _bullet)
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
                Collect(_MobsL[i]);
            }
            _MobsL.Clear();
        }
    }
}
