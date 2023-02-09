using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpreadBulletLauncher : MonoBehaviour
{
    public SpBulletControlScript m_shotPrefab; // �e�̃v���n�u
    public float m_shotSpeed; // �e�̈ړ��̑���
    public float m_shotAngleRange; // �����̒e�𔭎˂��鎞�̊p�x
    public float m_shotTimer; // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[
    public int m_shotCount; // �e�̔��ː�
    public float m_shotInterval; // �e�̔��ˊԊu�i�b�j
    public float angle;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[���X�V����
        m_shotTimer += Time.deltaTime;

        // �܂��e�̔��˃^�C�~���O�ł͂Ȃ��ꍇ�́A�����ŏ������I����
        if (m_shotTimer < m_shotInterval) return;

        // �e�̔��˃^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g����
        m_shotTimer = 0;
        if (isPressed) 
        {
            // �e�𔭎˂���
            ShootNWay(angle, m_shotAngleRange, m_shotSpeed, m_shotCount);
        }
    }
    // �e�𔭎˂���֐�
    private void ShootNWay(
        float angleBase, float angleRange, float speed, int count)
    {
        var pos = transform.localPosition; // �v���C���[�̈ʒu
        var rot = transform.localRotation; // �v���C���[�̌���

        // �e�𕡐����˂���ꍇ
        if (1 < count)
        {
            // ���˂���񐔕����[�v����
            for (int i = 0; i < count; ++i)
            {
                // �e�̔��ˊp�x���v�Z����
                var angle = angleBase +
                    angleRange * ((float)i / (count - 1) - 0.5f);
                // ���˂���e�𐶐�����
                var shot = Instantiate(m_shotPrefab, pos, rot);

                // �e�𔭎˂�������Ƒ�����ݒ肷��
                shot.Init(angle, speed);
            }
        }
    }
    public void InputBullet(InputAction.CallbackContext context)
    {
        isPressed = Keyboard.current.spaceKey.IsPressed();
    }

}
