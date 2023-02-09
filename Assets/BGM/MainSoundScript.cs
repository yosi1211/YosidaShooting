
using System.Collections;
using UnityEngine;

public class MainSoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DontDestroyEnbled = true;


    void Start()
    {
        if (DontDestroyEnbled)
        {
            DontDestroyOnLoad(this);
        }
    }
}
