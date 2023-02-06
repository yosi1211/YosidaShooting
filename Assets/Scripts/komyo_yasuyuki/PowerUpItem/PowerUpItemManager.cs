using UnityEngine;
using PoolControler_Summon;

public class PowerUpItemManager : MonoBehaviour
{
    [SerializeField]
    ObjectPoolController_Summon parentdate;
    [SerializeField]
    GameObject PItem;
    bool check = false;
    bool caal = true;
    GameObject root;
    private GameObject keep;
    private void Start()
    {
        PItem.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (caal)
        {
            //�����_���Ȑe�I�u�W�F�N�g��
            root = PItem.transform.parent.gameObject;
            if (keep != null && keep != root) {
                caal = false;
            }
            keep = root;
        }
        if (root.activeSelf)
        {
            PItem.transform.position = root.transform.position;
            check = true;
        }
        else{
            //�e�I�u�W�F�N�g����
            PItem.transform.parent = null;
            //����script���A�^�b�`����Ă���I�u�W�F�N�g�̎q����
            PItem.transform.parent = transform.gameObject.transform;
            if (check)
            {
                PItem.SetActive(true);
                check = false;
            }
        }
    }
}
