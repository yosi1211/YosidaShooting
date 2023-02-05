using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_360;

public class BombCollision : MonoBehaviour
{
    [SerializeField] EnemyManager _enemymanager;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Enemy")
    //    {
    //        _enemymanager.EnemyHPManager(10);
    //    }
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _enemymanager.EnemyHPManager(10);
        }
    }
}
