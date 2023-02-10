using System.Collections.Generic;
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
        [SerializeField] private List<PlayerManager> playerList;
        private void Update()
        {
            if (timer.Getendtime())
            {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }
            if (playerList[0].GetLifeStock() == 0) {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }
            if (playerList[1].GetLifeStock() == 0)
            {
                result.SetActive(true);
                Invoke("BackTitl", time);
            }
            if (playerList[2].GetLifeStock() == 0)
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
