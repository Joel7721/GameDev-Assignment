using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 targetPos;
    private Vector3 direction;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        //targetPos = GetRandomPointInCircle();
        targetPos = GetRandomPointOnXAxis();
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

        if (enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        direction = (targetPos - enemy.transform.position).normalized;

        //enemy.MoveEnemy(direction * enemy.RandomMovementSpeed);
        enemy.MoveEnemy(new Vector2(direction.x * enemy.RandomMovementSpeed, enemy.RB.velocity.y));

        /*if ((enemy.transform.position - targetPos).sqrMagnitude < 0.01f)
        {
            targetPos = GetRandomPointInCircle();
        }*/

        if (Mathf.Abs(enemy.transform.position.x - targetPos.x) < 0.1f)
        {
            targetPos = GetRandomPointOnXAxis();
        }
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

    /*private Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.RandomMovementRange;
    }*/

    private Vector3 GetRandomPointOnXAxis()
    {
        float randomX = Random.Range(-enemy.RandomMovementRange, enemy.RandomMovementRange);
        return new Vector3(enemy.transform.position.x + randomX, enemy.transform.position.y, enemy.transform.position.z);
    }
}
