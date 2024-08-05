using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;


//I still need to implement a way for the player to respawn after being killed
//I will also later implement some player interactions, but that will be added when I have more traps coded

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


    

    //public float newCameraSize = 5f;
    //public Vector3 newCameraPosition = new Vector3(0f, 0f, -10f);



   

    private void Awake()
    {
       
    }

    private void Start()
    {
      

        Camera mainCamera = Camera.main;

        mainCamera.orthographicSize = 5f;

        mainCamera.transform.position = new Vector3(0f, 0f, -10f);

        

       
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
       

            
            if (collision.gameObject.name == "Trigger" || collision.gameObject.name == "Trigger_Square" || collision.gameObject.name == "Enemy")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.ChangeDeathCounter(deathAmount);
                    Debug.Log("Trigger");
                    //death = true;
                    respawnPlayer.Invoke();

                

                }
                else
                {
                    Debug.Log("Game manager is missing.");
                }
            }

        if(collision.gameObject.name == "CameraTrigger")
        {
            
            Debug.Log("Touch Red");
            moveCamera1();

        }
      
        

        

        
        /*
        if (collision.gameObject.name == "CameraTrigger" && collision.gameObject.name == "CameraTrigger2")
        {
            
            Debug.Log("Fail collision");



            Camera mainCamera = Camera.main;

            if(mainCamera != null)
            {
                mainCamera.orthographicSize = 5f;

                mainCamera.transform.position = new Vector3(10f, 10f, 10f);
            }
            else
            {
                Debug.LogError("No Camera");
            }
        }*/

        
        
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

        //gameObject.SetActive(false);

        

        
    }

    public void movePlayer1()
    {
        transform.position = new Vector3(-7.47f, 1.83f);
    }

    public void movePlayer2()
    {
        transform.position = new Vector3(-7.47f, -2.57f);
    }


    public void moveCamera1()
    {

        

        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(10f, 10f, 10f);
        }
        else
        {
            Debug.LogError("No Camera");
        }
    }



   


   


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
