using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_Summon;

public class PowerUpItemManager : MonoBehaviour
{
    [SerializeField]
    ObjectPoolController_Summon parentdate;
    [SerializeField]
    GameObject PItem;
    bool check = false;
    bool call = true;

    private void Start()
    {
        PItem.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //�����_���Ȑe�I�u�W�F�N�g��
        GameObject root = PItem.transform.parent.gameObject;
        if (root.activeSelf)
        {
            if (call)
            {
                PItem.transform.position = root.transform.position;
            }
        }
        else{
            //�e�I�u�W�F�N�g����
            PItem.transform.parent = null;
            //����script���A�^�b�`����Ă���I�u�W�F�N�g�̎q����
            PItem.transform.parent = transform.gameObject.transform;
            check = true;
        }
        if (check)
        {
            //�\��
            PItem.SetActive(true);
        }
    }
}
