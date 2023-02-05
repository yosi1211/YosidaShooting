using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolControler_Summon;

public class PowerUpItem : MonoBehaviour
{
    [SerializeField]
    int speed;
    private void Awake()
    {
    }
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
            //powerUPèàóù
        }
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
