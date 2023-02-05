using UnityEngine;

namespace Power
    {
    public class PowerUpItem : MonoBehaviour
    {
        [SerializeField]
        int speed;
        [SerializeField]
        OptionSummon optionSummon;
        private void Awake()
        {
        }
        void Update()
        {
            transform.position -= transform.up * speed * Time.deltaTime;
            if (gameObject.activeSelf) {
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("�i���e�B�u");
            if (collision.gameObject.CompareTag("Player")) {
                gameObject.SetActive(false);
                //powerUP����
                optionSummon.SetLimit(1);
            }
        }
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}
