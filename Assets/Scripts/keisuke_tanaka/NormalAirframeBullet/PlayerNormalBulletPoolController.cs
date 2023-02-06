using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalBulletPoolController : MonoBehaviour
{
    //�e�̃v���n�u
    [SerializeField] PlayerNormalBulletController bullet;
    //�������鐔
    [SerializeField] int maxCount;
    //���������e���i�[����Queue
    Queue<PlayerNormalBulletController> bulletQueue;
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
        bulletQueue = new Queue<PlayerNormalBulletController>();

        //�e�𐶐����郋�[�v
        for (int i = 0; i < maxCount; i++)
        {
            //����
            PlayerNormalBulletController tmpBullet = Instantiate(bullet, setPos, setRot, transform);
            //Queue�ɒǉ�
            bulletQueue.Enqueue(tmpBullet);
        }
    }


    //�e��݂��o������
    public PlayerNormalBulletController Launch(Vector3 _pos)//, Quaternion rot)
    {
        //Queue����Ȃ�null
        if (bulletQueue.Count <= 0) return null;
        //Queue����e������o��
        PlayerNormalBulletController tmpBullet = bulletQueue.Dequeue();
        //�e��\������
        tmpBullet.gameObject.SetActive(true);
        //�n���ꂽ���W�ɒe���ړ�����
        tmpBullet.ShowInStage(_pos/*,rot*/);
        //�Ăяo�����ɓn��
        return tmpBullet;
    }

    //�e�̉������
    public void Collect(PlayerNormalBulletController _bullet)
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
