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
        [SerializeField] bool damageFlag;
        [SerializeField] GameObject BombActive;

        void Start()
        {
            damageFlag= false;
        }

        //void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.tag == "EnemyBullet" && !damageFlag)
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
            if (collision.gameObject.tag == "EnemyBullet" && !damageFlag)
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
            if (collision.gameObject.tag == "EnemyBullet" && !damageFlag)
            {
                damageFlag = true;
                LifeStock--;
                player.SetActive(false);
                BombActive.SetActive(false);
                Invoke("Respawn", 3.0f);
            }
        }
        private void Respawn()
        {
            damageFlag = false;
            player.SetActive(true);
            BombActive.SetActive(true);
            player.tag = "Dead";
            Invoke("Invisible", 3.0f);
        }
        public float GetLifeStock()
        {
            return LifeStock;
        }
        private void Invisible()
        {
            player.tag = "Player";
        }
    }
}