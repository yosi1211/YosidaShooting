using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombInstantiate : MonoBehaviour
{
    [SerializeField] private List<GameObject> bombList;
    [SerializeField] GameObject PrefabBomb;
    [SerializeField] GameObject firingBomb;

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
        for(int i = 0; i < bombList.Count;i++)
        {
            bombList[i].gameObject.SetActive(false);
        }
        Vector3 bombPosition = firingBomb.transform.parent.position;
        if(ButtonFlag == 1)
        {
            ButtonFlag = 0;
            GameObject pos = Instantiate(PrefabBomb, bombPosition, transform.rotation);
            pos.SetActive(true);
            pos.GetComponent<BombShot>().InitPos(new Vector3(0, 0, 0.2f));
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
