using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTitl : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.F12))
        {
            Debug.Log("F12");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
