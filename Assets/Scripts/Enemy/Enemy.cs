using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Move info")]
    public float moveSpeed = 2f;
    public float idleTime;
    public float battleTime;

    public int attackCoolDown;
    [HideInInspector]public float lastTimeAttacked;

    #region States
    public EnemyStateMachine stateMachine { get; private set; }
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyBattleState battleState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine, "idle", this);
        moveState = new EnemyMoveState(this, stateMachine, "move", this);
        battleState = new EnemyBattleState(this, stateMachine, "move", this);
        attackState = new EnemyAttackState(this, stateMachine, "attack", this);
    }

    public RaycastHit2D isPlayerDetected() => Physics2D.Raycast(playerCheck.position, Vector2.right * facingDir, playerCheckDistance, whatIsPlayer);
    //public bool isPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsPlayer);

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        stateMachine.currentState.Update();
        idleTime = Time.time;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(playerCheck.position, new Vector3(playerCheck.position.x + playerCheckDistance * facingDir, playerCheck.position.y));
    }

    public void AnimationTrigger()
    {
        stateMachine.ChangeState(idleState);
    }
}
