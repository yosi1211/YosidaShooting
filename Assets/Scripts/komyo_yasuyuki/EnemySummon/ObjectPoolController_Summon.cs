using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Summon
{
    public class ObjectPoolController_Summon : MonoBehaviour
    {
        //���X�g�̎擾
        List<SummonEnemyController> _SummonL;
        int listCount = 0;
        //��������G�̃v���n�u
        [SerializeField] SummonEnemyController bullet;
        //�������鐔
        int maxCount = 4;
        //���������G���i�[����Queue
        Queue<SummonEnemyController> bulletQueue;
        //���񐶐����̃|�W�V����
        Vector3 setPos = new Vector3(100, 100, 0);
        Quaternion setRot = Quaternion.identity;
        //�z�u�p�^�[���p
        int count = 1;
        [SerializeField]
        float _left;
        Vector3 left;
        [SerializeField]
        float _right;
        Vector3 right;
        [SerializeField]
        float _down;
        Vector3 down;
        [SerializeField]
        float _Maxidown;
        Vector3 Maxidown;
        //�N�����̏���
        private void Awake()
        {
            //Queue�̏�����
            bulletQueue = new Queue<SummonEnemyController>();
            //���X�g�̏�����
            _SummonL = new List<SummonEnemyController>();
            listCount = _SummonL.Count;
            //�G�𐶐����郋�[�v
            for (int i = 0; i < maxCount; i++)
            {
                //����
                SummonEnemyController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
                //Queue�ɒǉ�
                bulletQueue.Enqueue(tmpBullet);
            }
        }
                //�݂��o������
        public SummonEnemyController Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (bulletQueue.Count <= 0) return null;
            //Queue����G������o��
            SummonEnemyController tmpBullet = bulletQueue.Dequeue();
            //�G��\������
            tmpBullet.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            _SummonL.Add(tmpBullet);
            //�n���ꂽ���W�Ɉړ�����
            tmpBullet.ShowInStage(_pos);
            switch (count) {
                case 1:
                    right.x = _right;
                    tmpBullet.transform.position += right;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 2:
                    right.x = _right*2;
                    tmpBullet.transform.position += right;
                    Maxidown.y = _Maxidown;
                    tmpBullet.transform.position += Maxidown;
                    count++;
                    break;
                case 3:
                    left.x = _left;
                    tmpBullet.transform.position += left;
                    down.y = _down;
                    tmpBullet.transform.position += down;
                    count++;
                    break;
                case 4:
                    left.x = _left*2;
                    tmpBullet.transform.position += left;
                    Maxidown.y = _Maxidown;
                    tmpBullet.transform.position += Maxidown;
                    count = 1;
                    break;
                default:
                    Debug.Log("�i���e�B�u�s���ł�!!!!!!!");
                    break;
            }
            //�Ăяo�����ɓn��
            return tmpBullet;
        }
        //�������
        public void Collect(SummonEnemyController _bullet)
        {
            //�Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            bulletQueue.Enqueue(_bullet);
        }
        public void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SummonL[i]);
            }
            _SummonL.Clear();
        }
    }
}
