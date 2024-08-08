using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.Events;



public class Player : MonoBehaviour//, IKillable
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;

    public float movingInput;

    public LayerMask whatIsGround;
    public float groundCheckDistance;
    private bool isGrounded;

    public int deathAmount;


    //variables for win condition
    public bool win1 = false;
    public bool win2 = false;
    public bool win3 = false;
    public bool win4 = false;
    public bool win5 = false;
    public bool win6 = false;
    public bool win7 = false;
    public bool win8 = false;
    public bool win9 = false;
    public bool win10 = false;


    //Events used to ensure that when something happes to one character it happens to the other.
    public UnityEvent respawnPlayer;
    public UnityEvent moveOne;
    public UnityEvent moveTwo;
    public UnityEvent moveThree;
    public UnityEvent moveFour;
    public UnityEvent moveFive;
    public UnityEvent moveSix;
    public UnityEvent moveSeven;
    public UnityEvent moveEight;
    public UnityEvent moveNine;
    public UnityEvent moveTen;

    public UnityEvent restart;


    private void Awake()
    {
       
    }

    private void Start()
    {

        //Positions camera & player in the correct position when the game starts

        startingCamera();

        respawnPlayer.Invoke();

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


        level1();
        level2();
        level3();
        level4();
        level5();
        level6();
        level7();
        level8();
        level9();
        level10();

        winCondition();

        
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
       
        
            //If the player touches one of these objects they "die". Player resets at first level.
            if (collision.gameObject.name == "Trigger" || collision.gameObject.name == "Trigger_Square" || collision.gameObject.name == "Enemy")
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.ChangeDeathCounter(deathAmount);
              
                    respawnPlayer.Invoke();

                    startingCamera();

                    restart.Invoke();

                


            }
                else
                {
                    Debug.Log("Game manager is missing.");
                }
            }


        //The following "CameraTrigger" if statements use the "moveCamera" methods to move the camera each time the player beats a level. This also sets win# to true depending on the level.
        if(collision.gameObject.name == "CameraTrigger")
        {
            
            Debug.Log("Touch Red");
            moveCamera1();
            win1 = true;

        }

        if (collision.gameObject.name == "CameraTrigger2")
        {

            Debug.Log("Touch Red");
            moveCamera2();
            win2 = true;

        }

        if (collision.gameObject.name == "CameraTrigger3")
        {

            Debug.Log("Touch Red");
            moveCamera3();
            win3 = true;

        }

        if (collision.gameObject.name == "CameraTrigger4")
        {

            Debug.Log("Touch Red");
            moveCamera4();
            win4 = true;

        }

        if (collision.gameObject.name == "CameraTrigger5")
        {

            Debug.Log("Touch Red");
            moveCamera5();
            win5 = true;

        }

        if (collision.gameObject.name == "CameraTrigger6")
        {

            Debug.Log("Touch Red");
            moveCamera6();
            win6 = true;

        }

        if (collision.gameObject.name == "EnemySafe")
        {

            Debug.Log("Touch Red");
            moveCamera7();
            win7 = true;

        }

        if (collision.gameObject.name == "CameraTrigger8")
        {

            Debug.Log("Touch Red");
            moveCamera8();
            win8 = true;

        }

        if (collision.gameObject.name == "CameraTrigger9")
        {

            Debug.Log("Touch Red");
            moveCamera9();
            win9 = true;

        }

        if (collision.gameObject.name == "EnemySafe2")
        {
             

            Debug.Log("Touch Red");

            startingCamera();

            respawnPlayer.Invoke();

            win10 = true;

            

        }


    }

    //Move player methods teleports the player to next level

    public void movePlayer1()
    {
        transform.position = new Vector3(-7.47f, 1.83f);
    }

    public void movePlayer2()
    {
        transform.position = new Vector3(-7.47f, -2.57f);
    }
    public void movePlayer3()
    {
        transform.position = new Vector3(19.85f, 1.84f);
    }

    public void movePlayer4()
    {
        transform.position = new Vector3(19.85f, -7.87f);
    }
    public void movePlayer5()
    {
        transform.position = new Vector3(55.7f, 3.35f);
    }

    public void movePlayer6()
    {
        transform.position = new Vector3(55.7f, -1.98f);
    }

    public void movePlayer7()
    {
        transform.position = new Vector3(80.52f, 2.81f);
    }

    public void movePlayer8()
    {
        transform.position = new Vector3(80.52f, -2.75f);
    }

    public void movePlayer9()
    {
        transform.position = new Vector3(138.8f, 28.71f);
    }

    public void movePlayer10()
    {
        transform.position = new Vector3(138.8f, 7f);
    }

    public void movePlayer11()
    {
        transform.position = new Vector3(-6.23f, -50.33f);
    }

    public void movePlayer12()
    {
        transform.position = new Vector3(-6.23f, -55.08f);
    }

    public void movePlayer13()
    {
        transform.position = new Vector3(19.64f, -50.58f);
    }

    public void movePlayer14()
    {
        transform.position = new Vector3(19.64f, -55.5f);
    }

    public void movePlayer15()
    {
        transform.position = new Vector3(45.4f, -50.3f);
    }

    public void movePlayer16()
    {
        transform.position = new Vector3(45.4f, -55.14f);
    }

    public void movePlayer17()
    {
        transform.position = new Vector3(71.21f, -51.03f);
    }

    public void movePlayer18()
    {
        transform.position = new Vector3(71.21f, -55.96f);
    }

    public void movePlayer19()
    {
        transform.position = new Vector3(139.38f, -24.4f);
    }

    public void movePlayer20()
    {
        transform.position = new Vector3(139.38f, -50.0f);
    }

    public void movePlayer21()
    {
        transform.position = new Vector3(219.65f, -36.13f);
    }

    public void movePlayer22()
    {
        transform.position = new Vector3(211.62f, -36.22f);
    }

   
    //Camera methods control camera movement and size
    public void startingCamera()
    {
        Camera mainCamera = Camera.main;

        mainCamera.orthographicSize = 5f;

        mainCamera.transform.position = new Vector3(0f, 0f, -10f);
    }


    public void moveCamera1()
    {

        

        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 7.46f;

            mainCamera.transform.position = new Vector3(29.33f, -1.97f, -10f);

            moveOne.Invoke();
        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera2()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5.057717f;

            mainCamera.transform.position = new Vector3(60.19f, 0.97f, -10f);

            moveTwo.Invoke();
        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera3()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5.057717f;

            mainCamera.transform.position = new Vector3(85.57f, 1.31f, -10f);

            moveThree.Invoke();

            
        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera4()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 22.04757f;

            mainCamera.transform.position = new Vector3(136.1f, 9.5f, -10f);

            moveFour.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera5()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(-0.1f, -52.12f, -10f);

            moveFive.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera6()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(24.87f, -51.93f, -10f);

            moveSix.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera7()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(51.76f, -52.13f, -10f);

            moveSeven.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera8()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(77.23f, -51.88f, -10f);

            moveEight.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera9()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 22.04757f;

            mainCamera.transform.position = new Vector3(136.8f, -45.4f, -10f);

            moveNine.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    public void moveCamera10()
    {



        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.orthographicSize = 5f;

            mainCamera.transform.position = new Vector3(214.18f, -32.86f, -10f);

            moveTen.Invoke();


        }
        else
        {
            Debug.LogError("No Camera");
        }
    }

    //Allows the player to choose the level by pressing any number between 1-0 on the keyboard (includes 1 & 0)
    public void level1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startingCamera();
            respawnPlayer.Invoke();
            
        }
    }

    public void level2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            moveCamera1();
            moveOne.Invoke();

        }
    }

    public void level3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            moveCamera2();
            moveTwo.Invoke();

        }
    }

    public void level4()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            moveCamera3();
            moveThree.Invoke();

        }
    }

    public void level5()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            moveCamera4();
            moveFour.Invoke();

        }
    }

    public void level6()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            moveCamera5();
            moveFive.Invoke();

        }
    }

    public void level7()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            moveCamera6();
            moveSix.Invoke();

        }
    }

    public void level8()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            moveCamera7();
            moveSeven.Invoke();

        }
    }

    public void level9()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            moveCamera8();
            moveEight.Invoke();

        }
    }

    public void level10()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            moveCamera9();
            moveNine.Invoke();

        }
    }

    //Checks if all levels have been completed properly. This means that the player has gone through each level without "dying". If all 10 are true, player is teleported to win "screen".
    public void winCondition()
    {
        if(win1 == true &&  win2 == true && win3 == true && win4 == true && win5 == true && win6 == true && win7 == true && win8 == true && win9 == true && win10 == true)
        {
            moveCamera10();
        }
        else
        {

        }
    }

    //Resets all win conditions to false when player "dies"
    public void resetWinCondition()
    {
        win1 = false;
        win2 = false;
        win3 = false;
        win4 = false;
        win5 = false;
        win6 = false;
        win7 = false;
        win8 = false;
        win9 = false;
        win10 = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
