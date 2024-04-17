using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Move info")]
    public float moveSpeed = 12f;

    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;

    #region 애니메이터
    public Animator anim { get; private set; } // 프로퍼티
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public EnemyStateMachine stateMachine { get; private set; }
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    #endregion

    public void Awake()
    {
        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine, "idle");
        moveState = new EnemyMoveState(this, stateMachine, "move");
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.currentState.Update();
    }

    #region Velocity
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipCintroller(_xVelocity);
    }
    #endregion

    #region Collision
    public bool isGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
    #endregion

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipCintroller(float _x)
    {
        //if (rb.velocity.x > 0 && !facingRight)
        if (_x > 0 && !facingRight)
            Flip();
        //else if (rb.velocity.x < 0 && facingRight)
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion
}
