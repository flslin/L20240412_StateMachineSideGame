using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyGroundedState
{
    public EnemyMoveState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(x * enemy.moveSpeed, rb.position.y);

        if (enemy.isWallDetected() && enemy.isGroundDetected())
            enemy.Flip();
    }
}
