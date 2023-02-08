using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Image : MonoBehaviour
{
    [SerializeField, Header("�c�@�\��image")]
    Image machine_image;
    [SerializeField, Header("�n�[�h�X�v���C�g")]
    Sprite hardsprite;
    [SerializeField, Header("�m�[�}���X�v���C�g")]
    Sprite normalsprite;
    [SerializeField, Header("�C�[�W�[�X�v���C�g")]
    Sprite easysprite;

    void Start()
    {
        machine_image = GetComponent<Image>();
        switch (Ownmachine_Inform.ownmachine)   //�@�̂ɂ���ĕύX
        {
            case 0:
                machine_image.sprite = hardsprite;
                break;
            case 1:
                machine_image.sprite = normalsprite;
                break;
            case 2:
                machine_image.sprite = easysprite;
                break;
                default:    //�����ɗ�����G���[
                machine_image.sprite = hardsprite;
                break;
        }
    }
}
