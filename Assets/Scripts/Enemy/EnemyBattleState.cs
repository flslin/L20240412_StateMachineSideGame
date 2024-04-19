using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleState : EnemyState
{
    private Enemy enemy;
    private Transform player;
    private int moveDir = 1;

    public EnemyBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.currentState != enemy.idleState && enemy.isPlayerDetected())
        {
            if (player.position.x > enemy.transform.position.x)
                moveDir = 1;
            else if (player.position.x < enemy.transform.position.x)
                moveDir = -1;

            enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.rb.velocity.y);
        }
    }


}
