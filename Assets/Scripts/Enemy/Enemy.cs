using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemyMoveable, ITriggerCheckable
{
    public Rigidbody2D RB { get; set; }
    public Rigidbody2D rb;
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public bool IsAggroed { get; set; }

    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this,StateMachine);
    }


    // Start is called before the first frame update
    void Start()
    {
        RB= GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);

        RB.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void MoveEnemy(Vector2 velocity)
    {
       RB.velocity = velocity;
    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }
}
