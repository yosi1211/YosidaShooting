using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Option
{
    public class ObjectPoolController_Option : MonoBehaviour
    {
        //���X�g�̎擾
        List<SummonOptionController> _SummonL;
        int listCount = 0;
        //��������G�̃v���n�u
        [SerializeField] SummonOptionController bullet;
        //�������鐔
        int maxCount = 2;
        //���������G���i�[����Queue
        Queue<SummonOptionController> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        //�z�u�p�^�[���p
        int count = 1;
        float _left = -1;
        Vector3 left;
        float _right = 1;
        Vector3 right;
        float _down = -1;
        Vector3 down;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<SummonOptionController>();
            //���X�g�̏�����
            _SummonL = new List<SummonOptionController>();
            listCount = _SummonL.Count;
            //�G�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                SummonOptionController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }
        //�݂��o������
        public SummonOptionController Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����G������o��
            SummonOptionController tmpBullet = bulletQueue.Dequeue();
            //�G��\������
            tmpBullet.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            _SummonL.Add(tmpBullet);
            //�n���ꂽ���W�ɒe���ړ�����
            tmpBullet.ShowInStage(_pos);
            switch (count)
            {
                case 1:
                    right.x = _right;
                    tmpBullet.transform.position += right;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 2:
                    left.x = _left;
                    tmpBullet.transform.position += left;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count = 1;
                    break;
                default:
                    Debug.Log("switch default");
                    break;
            }
            //�Ăяo�����ɓn��
            return tmpBullet;
        }
        //�e�̉������
        public void Collect(SummonOptionController _bullet)
        {
            //�e�̃Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SummonL[i]);
            }
            _SummonL.Clear();
        }
    }
}