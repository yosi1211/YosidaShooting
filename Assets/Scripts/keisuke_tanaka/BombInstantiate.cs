using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstantiate : MonoBehaviour
{
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
        Vector3 bombPosition = firingBomb.transform.parent.position;
        if(ButtonFlag == 1)
        {
            ButtonFlag = 0;
            GameObject pos = Instantiate(PrefabBomb, bombPosition, transform.rotation);
            pos.SetActive(true);
            pos.GetComponent<BombShot>().InitPos(new Vector3(0, 0, 0.2f));
        }
    }
}
