using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContrllerInputSystem : MonoBehaviour
{
    [SerializeField, Header("ÉvÉåÉCÉÑÅ[ÇÃë¨Ç≥")]
    private float speed = 3;

    private Vector2 inputValue = new Vector2();

    private Vector2 move = new Vector2();

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        move = new Vector2(inputValue.x, inputValue.y);
        move = move * speed * Time.deltaTime;
        transform.Translate(move);
    }

    public void PlayerInput(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }
}
