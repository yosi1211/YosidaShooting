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

    float xLimit = 2.8f;

    float yLimit = 5.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMove();
        Vector3 currentPos = transform.position;

        currentPos.x = Mathf.Clamp(currentPos.x,-xLimit, xLimit);
        currentPos.y = Mathf.Clamp(currentPos.y,-yLimit, yLimit);

        transform.position = currentPos;
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
