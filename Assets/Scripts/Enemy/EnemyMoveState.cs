using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    Enemy enemy;

    public EnemyMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
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

        enemy.SetVelocity(2 * enemy.moveSpeed * enemy.facingDir, rb.position.y);

        if (enemy.isWallDetected() || !enemy.isGroundDetected())
            enemy.Flip();
    }
}