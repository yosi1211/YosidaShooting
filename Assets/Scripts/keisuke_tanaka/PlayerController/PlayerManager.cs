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

        [SerializeField, Header("無敵時間")]
        float invincibleTime = 1.0f;
        [SerializeField, Header("プレイヤーのスプライト")]
        SpriteRenderer sp;
        private int invisible = 0;
        bool invincible = false;
        int timer = 0;
        void Start()
        {
            damageFlag = false;
        }

        private void Update()
        {
            if (invincible)
            {
                timer++;
                if (timer % 50 > 25)
                {
                    invisible = 1;
                }
                else
                {
                    invisible = 0;
                }
            }
            else
            {
                timer = 0;
            }
            sp.color = new Color(1f, 1f, 1f, invisible);
            invisible = 1;
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
            player.SetActive(true);
            invincible = true;
            BombActive.SetActive(true);
            Invoke("Invisible", invincibleTime);
        }
        public float GetLifeStock()
        {
            return LifeStock;
        }
        private void Invisible()
        {
            damageFlag = false;
            invincible = false;
        }
    }
}