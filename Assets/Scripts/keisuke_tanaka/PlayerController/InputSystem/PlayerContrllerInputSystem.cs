using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContrllerInputSystem : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの速さ")]
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
        move = inputValue * speed*Time.deltaTime;
        transform.Translate(move);
    }

    public void PlayerInput(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
        Debug.Log(inputValue);
    }
}
