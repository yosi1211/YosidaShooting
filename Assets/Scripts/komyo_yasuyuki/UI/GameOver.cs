using UnityEngine;
using UnityEngine.SceneManagement;

namespace gameover
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        private GameObject result;
        [SerializeField]
        private float time;
        [SerializeField]
        TimerManager timer;
        private void Update()
        {
            if (timer.Getendtime())
            {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }
        }
        public void BackTitl()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
