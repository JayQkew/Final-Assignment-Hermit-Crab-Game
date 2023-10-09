using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 9f;
    public Rigidbody2D rb;

    Vector2 movement;

    public Transform playerSprite;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Flip the player's sprite based on movement direction
        if (movement.x > 0)
        {
            playerSprite.localScale = new Vector3(-1, 1, 1); // No scaling on x-axis for facing right
        }
        else if (movement.x < 0)
        {
            playerSprite.localScale = new Vector3(1, 1, 1); // Flip the sprite on x-axis for facing left
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
