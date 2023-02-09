using UnityEngine;

public class EscapeMainTitl : MonoBehaviour
{
    void Update()
    {
        EndGame();
    }
    private void EndGame()
    {
        if (Input.GetKey(KeyCode.F12))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
