using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    [SerializeField] string SceneName;
 
    public void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}
