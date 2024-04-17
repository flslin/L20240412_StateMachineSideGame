using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
    public EnemyGroundedState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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

        if (enemy.isGroundDetected())
            stateMachine.ChangeState(enemy.moveState);
    }
}
