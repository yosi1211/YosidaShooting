using System.Collections.Generic;
using UnityEngine;

namespace PoolControler_Option
{
    public class ObjectPoolController_Option : MonoBehaviour
    {
        //���X�g�̎擾
        List<SummonOptionController> _SummonOL;
        int listCount = 0;
        //��������G�̃v���n�u
        [SerializeField] SummonOptionController option;
        //�������鐔
        int maxCount = 2;
        //���������G���i�[����Queue
        Queue<SummonOptionController> optionQueue;
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
            optionQueue = new Queue<SummonOptionController>();
            //���X�g�̏�����
            _SummonOL = new List<SummonOptionController>();
            listCount = _SummonOL.Count;
            //�I�v�V�����𐶐�
            for (int i = 0; i < maxCount; i++)
            {
                //����
                SummonOptionController tmpOption = Instantiate(option, setPos, setRot, transform);
                //Queue�ɒǉ�
                optionQueue.Enqueue(tmpOption);
            }
        }
        //�݂��o������
        public SummonOptionController Launch(Vector3 _pos)
        {
            //Queue����Ȃ�null
            if (optionQueue.Count <= 0) return null;
            //Queue�������o��
            SummonOptionController tmpOption = optionQueue.Dequeue();
            //�\������
            tmpOption.gameObject.SetActive(true);
            //���X�g�Ɋi�[
            _SummonOL.Add(tmpOption);
            //�n���ꂽ���W�Ɉړ�����
            tmpOption.ShowInStage(_pos);
            switch (count)
            {
                case 1:
                    right.x = _right;
                    tmpOption.transform.position += right;
                    down.y = _down;
                    tmpOption.transform.position += down;
                    count++;
                    break;
                case 2:
                    left.x = _left;
                    tmpOption.transform.position += left;
                    down.y = _down;
                    tmpOption.transform.position += down;
                    count = 1;
                    break;
                default:
                    Debug.Log("switch default");
                    break;
            }
            //�Ăяo�����ɓn��
            return tmpOption;
        }
        //�������
        public void Collect(SummonOptionController _bullet)
        {
            //�Q�[���I�u�W�F�N�g���\��
            _bullet.gameObject.SetActive(false);
            //Queue�Ɋi�[
            optionQueue.Enqueue(_bullet);
        }
        void CollectList()
        {
            for (int i = 0; i < listCount; i++)
            {
                Collect(_SummonOL[i]);
            }
            _SummonOL.Clear();
        }
    }
}