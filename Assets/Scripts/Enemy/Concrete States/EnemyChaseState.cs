using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{

    private Transform playerTransform;
    private float movementSpeed = 1.75f;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (!enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
            return;
        }

        Vector2 moveDirection = (playerTransform.position - enemy.transform.position).normalized;

        //enemy.MoveEnemy(moveDirection * movementSpeed);

        enemy.MoveEnemy(new Vector2(moveDirection.x * movementSpeed, enemy.RB.velocity.y));

    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
