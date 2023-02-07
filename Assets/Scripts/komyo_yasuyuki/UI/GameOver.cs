using UnityEngine;
using UnityEngine.SceneManagement;
using playermanager;

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
        //[SerializeField] PlayerManager Pmanager;
        private void Update()
        {
            if (timer.Getendtime())
            {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }
            /*if (Pmanager.GetLifeStock() == 0) {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }*/
        }
        public void BackTitl()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
