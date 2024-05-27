using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    public float movingInput;

    public LayerMask whatIsGround;
    public float groundCheckDistance;
    private bool isGrounded;

    public int deathAmount;

    void Start()
    {

    }


    void Update()
    {
        CollisionCheck();

        movingInput = Input.GetAxisRaw("Horizontal");

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.test++;
            if (isGrounded)
            {
                Jump();

            }
        }
    }

    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

            
            if (collision.gameObject.name == "Trigger")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.ChangeDeathCounter(deathAmount);
                    Debug.Log("Trigger");
                }
                else
                {
                    Debug.Log("Game manager is missing.");
                }
            }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
