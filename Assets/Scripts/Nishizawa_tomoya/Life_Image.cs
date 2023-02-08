using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Image : MonoBehaviour
{
    [SerializeField, Header("残機表示image")]
    Image machine_image;
    [SerializeField, Header("ハードスプライト")]
    Sprite hardsprite;
    [SerializeField, Header("ノーマルスプライト")]
    Sprite normalsprite;
    [SerializeField, Header("イージースプライト")]
    Sprite easysprite;

    void Start()
    {
        machine_image = GetComponent<Image>();
        switch (Ownmachine_Inform.ownmachine)   //機体によって変更
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
                default:    //ここに来たらエラー
                machine_image.sprite = hardsprite;
                break;
        }
    }
}
