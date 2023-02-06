using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpBulletControlScript : MonoBehaviour
{
    private Vector3 velocity;

    void Update()
    {
        transform.localPosition += velocity;
    }
    public void Init(float angle, float speed)
    {
        var direction = Utils.GetDirection(angle);
        velocity = direction * speed;
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        Destroy(gameObject, 0.35f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyManager>().EnemyHPManager(10);
        }
    }
}