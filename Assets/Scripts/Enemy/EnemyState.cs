using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;

    protected bool triggerCalled;
    private string animBoolName;

    protected float x = 2;
    protected float y;

    protected Rigidbody2D rb;

    protected float stateTimer;
    public float idleTime;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        enemyBase.anim.SetBool(animBoolName, true);

        rb = enemyBase.rb;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;

        if (enemyBase.isPlayerDetected())
        {
            enemyBase.ZeroVelocity();
            stateTimer = enemyBase.battleTime;
            if (CanAttack())
            {
                stateMachine.ChangeState(enemyBase.battleState);
            }
        }
        else
        {
            if(stateTimer < 0)
                stateMachine.ChangeState(enemyBase.idleState);
            enemyBase.ZeroVelocity();
        }
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
    }

    private bool CanAttack()
    {
        if (Time.time >= enemyBase.lastTimeAttacked + enemyBase.attackCoolDown)
        {
            enemyBase.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
