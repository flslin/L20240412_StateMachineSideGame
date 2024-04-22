using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{

    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 2;

    public PlayerPrimaryAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        xInput = 0;//버그가있는거같아서 넣어줌


        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;


        float attackDir = player.facingDir;

        if (xInput != 0)
            attackDir = xInput;


        player.anim.SetInteger("comboCounter",comboCounter);
      
        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);
        


        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();


        player.StartCoroutine("BusyFor", 0.1f);
      

        comboCounter++;
        lastTimeAttacked = Time.time;
     
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.ZeroVelocity();




        if(triggerCalled)
            stateMachine.ChangeState(player.idleState);

    }
}
