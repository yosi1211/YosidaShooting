using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPoolController : MonoBehaviour
{
    //�e�̃v���n�u
    [SerializeField] PlayerHomingBulletController bullet;
    //�������鐔
    [SerializeField] int maxCount;
    //���������e���i�[����Queue
    Queue<PlayerHomingBulletController> bulletQueue;
    //���񐶐����̃|�W�V����
    Vector3 setPos = new Vector3(100, 100, 0);
    Quaternion setRot = Quaternion.identity;
    [SerializeField, Header("���x")]
    int density = 0;
    int z = 0;
    //PlayerBulletController bulletController;
    //�N�����̏���
    private void Awake()
    {
        //Queue�̏�����
        bulletQueue = new Queue<PlayerHomingBulletController>();

        //�e�𐶐����郋�[�v
        for (int i = 0; i < maxCount; i++)
        {
            //����
            PlayerHomingBulletController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
            //Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
        }
    }


    //�e��݂��o������
    public PlayerHomingBulletController Launch(Vector3 _pos)//, Quaternion rot)
    {
        //Queue����Ȃ�null
        if (bulletQueue.Count <= 0) return null;
        //Queue����e������o��
        PlayerHomingBulletController tmpBullet = bulletQueue.Dequeue();
        //�e��\������
        tmpBullet.gameObject.SetActive(true);
        //�n���ꂽ���W�ɒe���ړ�����
        tmpBullet.ShowInStage(_pos/*,rot*/);
        //�Ăяo�����ɓn��
        return tmpBullet;
    }

    //�e�̉������
    public void Collect(PlayerHomingBulletController _bullet)
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
