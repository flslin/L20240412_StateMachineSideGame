using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimSwordState : PlayerState
{
    //SwordSkill ss;

    public PlayerAimSwordState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //ss.GetComponent<SwordSkill>();
        player.skill.sword.DotsActive(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.ZeroVelocity();
        if (Input.GetKeyUp(KeyCode.Mouse1)/* && ss.isHave*/)
        {
            stateMachine.ChangeState(player.idleState);

        }
    }
}
