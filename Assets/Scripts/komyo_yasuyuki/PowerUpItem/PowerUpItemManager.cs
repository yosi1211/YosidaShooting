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
            //ランダムな親オブジェクトに
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
            //親オブジェクト解除
            PItem.transform.parent = null;
            //このscriptがアタッチされているオブジェクトの子供に
            PItem.transform.parent = transform.gameObject.transform;
            if (check)
            {
                PItem.SetActive(true);
                check = false;
            }
        }
    }
}
