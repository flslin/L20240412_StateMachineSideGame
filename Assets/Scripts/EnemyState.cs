using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    protected float x = 2;
    protected float y;
    private string animBoolName;

    protected Rigidbody2D rb;

    protected float stateTimer;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        enemy.anim.SetBool(animBoolName, true);
        rb = enemy.rb;
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);
    }
}
