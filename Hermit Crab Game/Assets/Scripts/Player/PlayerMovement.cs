using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private Vector2 move;
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private Vector2 currentVelocity = Vector2.zero;
    [SerializeField] private bool isWalking;


    [SerializeField] private float maxSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float stopTime;

    public Animator anim;

    public Transform playerSprite;

    void Start()
    {

    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MoveInput();

        isWalking = currentVelocity.magnitude > 0.01f;
        anim.SetBool("isWalking", isWalking);

        Flip(); // Flip the player's sprite based on movement direction
    }

    private void Flip()
    {
        if (movement.x > 0)
        {
            playerSprite.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else if (movement.x < 0)
        {
            playerSprite.localScale = new Vector3(0.5f, 0.5f, 1);
        }

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Move();
    }

    private void MoveInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputDirection != Vector2.zero)
        {
            currentVelocity += inputDirection * acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        // Limit the maximum speed (optional)
        currentVelocity = Vector2.ClampMagnitude(currentVelocity, moveSpeed);
    }
    private void Move()
    {
        rb.AddForce(currentVelocity * rb.mass);
    }
}
