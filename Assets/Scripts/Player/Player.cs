using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = 0.2f;
    
    public bool isBusy { get; private set; }

    [Header("Move info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash info")]
    //[SerializeField] private float dashCooldown; // 20240424 수정
    //private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }
     
    public SkillManager skill {  get; private set; }

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }
    public PlayerCounterAttackState counterAttack { get; private set; }
    public PlayerAimSwordState aimSword { get; private set; }
    public PlayerCatchSwordState catchSword { get; private set; }
    #endregion

    //public void SetIdleState()
    //{
    //    stateMachine.ChangeState(idleState);
    //    SetVelocity(0, 0);
    //}

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        airState = new PlayerAirState(this, stateMachine, "jump");
        dashState = new PlayerDashState(this, stateMachine, "dash");
        wallSlide = new PlayerWallSlideState(this, stateMachine, "wallSlide");
        wallJump = new PlayerWallJumpState(this, stateMachine, "jump");
        primaryAttack = new PlayerPrimaryAttack(this, stateMachine, "attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "counterAttack");
        aimSword = new PlayerAimSwordState(this, stateMachine, "aimSowrd");
        catchSword = new PlayerCatchSwordState(this, stateMachine, "catchSowrd");
    }

    protected override void Start()
    {
        base.Start();

        skill = SkillManager.instance;

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();

        CheckForDashInput();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
      
        yield return new WaitForSeconds(_seconds);
      
        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDashInput()
    {
        if (IsWallDetected())
            return;

        //dashUsageTimer -= Time.deltaTime; // 20240424 수정

        if(Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dash.CanUseSkill()/*dashUsageTimer <0*/)
        {
            //dashUsageTimer = dashCooldown; // 20240424 수정
            dashDir = Input.GetAxisRaw("Horizontal");

           if (dashDir == 0)
                dashDir = facingDir;

            stateMachine.ChangeState(dashState);
        }
           
    }
}
