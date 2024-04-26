using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonDeadState : SkeletonGroundedState
{
    private Collider2D collison;

    public SkeletonDeadState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
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
    }

    //private void OnTriggerEnter2D(Collider2D collison)
    //{
    //    if (collison.CompareTag("PlayerSword"))
    //        hit++;

    //    if (collison.CompareTag("PlayerSword") && hit == 3)
    //        enemy.stateMachine.ChangeState(enemy.deadState);
    //}
}
