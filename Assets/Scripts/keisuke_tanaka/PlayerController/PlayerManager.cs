using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playermanager
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private float LifeStock = 3;
        //[SerializeField] private int Life = 100;
        [SerializeField] GameObject player;

        //void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.tag == "EnemyBullet")
        //    {
        //        Life -= 1;
        //    }
        //    if (Life < 1)
        //    {
        //        LifeStock -= 1;
        //        Life = 100;
        //    }
        //}
        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                Life -= 1;
            }
            if (Life < 1)
            {
                LifeStock -= 1;
                Life = 100;
            }
            if(LifeStock == 0)
            {
                gameObject.SetActive(false);
            }
        }*/
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "EnemyBullet")
            {
                LifeStock--;
                player.SetActive(false);
                Invoke("Respawn", 3.0f);
            }
        }
        private void Respawn()
        {
            player.SetActive(true);
        }
        public float GetLifeStock()
        {
            return LifeStock;
        }
    }
}