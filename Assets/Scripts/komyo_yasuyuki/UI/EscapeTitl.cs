using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTitl : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("");
        }
    }
}
