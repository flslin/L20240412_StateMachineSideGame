using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    Enemy enemy;

    public EnemyIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        stateTimer = Time.time;

        if (stateTimer > 2)
        {
            stateMachine.ChangeState(enemy.moveState);
            enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, enemy.rb.velocity.y);
        }
        //else
        //    stateMachine.ChangeState(enemy.idleState);
    }
}
