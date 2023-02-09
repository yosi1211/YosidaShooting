using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombInstantiate : MonoBehaviour
{
    [SerializeField] private List<GameObject> bombList;
    [SerializeField,Header("�g�p����@�̂̎q�I�u�W�F�N�g��bomb�������ɓ����")]
    private List<GameObject> PrefabBomb;
    [SerializeField,Header("�g�p����@�̂̎q�I�u�W�F�N�g��BombCreatePos�������ɓ����")]
    private List<GameObject> firingBomb;

    private int ButtonFlag = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BombCreate()
    {
        if(Ownmachine_Inform.ownmachine == 0)
        {
            for (int i = 0; i < bombList.Count; i++)
            {
                bombList[i].gameObject.SetActive(false);
            }
            Vector3 bombPosition = firingBomb[0].transform.parent.position;
            if (ButtonFlag == 1)
            {
                ButtonFlag = 0;
                GameObject pos = Instantiate(PrefabBomb[0], bombPosition, transform.rotation);
                pos.SetActive(true);
                pos.GetComponent<BombShot>().InitPos(new Vector3(0, 0, 0.2f));
            }
        }
        if (Ownmachine_Inform.ownmachine == 1)
        {
            for (int i = 0; i < bombList.Count; i++)
            {
                bombList[i].gameObject.SetActive(false);
            }
            Vector3 bombPosition = firingBomb[1].transform.parent.position;
            if (ButtonFlag == 1)
            {
                ButtonFlag = 0;
                GameObject pos = Instantiate(PrefabBomb[1], bombPosition, transform.rotation);
                pos.SetActive(true);
                pos.GetComponent<BombShot>().InitPos(new Vector3(0, 0, 0.2f));
            }
        }
        if (Ownmachine_Inform.ownmachine == 2)
        {
            for (int i = 0; i < bombList.Count; i++)
            {
                bombList[i].gameObject.SetActive(false);
            }
            Vector3 bombPosition = firingBomb[2].transform.parent.position;
            if (ButtonFlag == 1)
            {
                ButtonFlag = 0;
                GameObject pos = Instantiate(PrefabBomb[2], bombPosition, transform.rotation);
                pos.SetActive(true);
                pos.GetComponent<BombShot>().InitPos(new Vector3(0, 0, 0.2f));
            }
        }
    }
    public void InputBomb(InputAction.CallbackContext context)
    {
        Debug.Log("ye");
        if (context.performed)
        {
            Debug.Log("a");
            BombCreate();
        }
    }
}
