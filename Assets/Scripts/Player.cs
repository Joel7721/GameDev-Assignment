using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IKillable
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    public float movingInput;

    public LayerMask whatIsGround;
    public float groundCheckDistance;
    private bool isGrounded;

    public int deathAmount;

    public bool death = false;

    public UnityEvent respawnPlayer;

    void Start()
    {

    }


    void Update()
    {
        CollisionCheck();

        movingInput = Input.GetAxisRaw("Horizontal");

        Move();

        Kill();

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
       

            
            if (collision.gameObject.name == "Trigger" || collision.gameObject.name == "Trigger_Square")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.ChangeDeathCounter(deathAmount);
                    Debug.Log("Trigger");
                    death = true;
                    

                }
                else
                {
                    Debug.Log("Game manager is missing.");
                }
            }
        
    }
    public void Kill()
    {
        if (death == true)
        {
            
            //Destroy(gameObject);

            respawnPlayer.Invoke();
            
        }
    }

    public void testInvoke()
    {
        Debug.Log("Test Invoke");
    }

    public void killPlayer()
    {
        //Debug.Log("dead");
        //Destroy(gameObject);

        gameObject.SetActive(false);

        
    }

  

   

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
