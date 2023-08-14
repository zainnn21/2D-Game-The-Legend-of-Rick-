using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntState : State
{
    protected D_StuntState stateData;
    protected bool isGrounded;
    protected bool isMovementStopped;
    protected bool isStuntTimeOver;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;

    public StuntState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,D_StuntState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = entity.CheckGround();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter()
    {
        base.Enter();

        isStuntTimeOver = false;
        isMovementStopped = false;
        entity.SetVelocity(stateData.stuntKnockbackSpeed, stateData.stuntKnockbackAngle, entity.lastDamageDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.stuntTime)
        {
            isStuntTimeOver = true;
        }

        if(isGrounded && Time.time >= startTime + stateData.stuntKockbackTime && !isMovementStopped)
        {
            isMovementStopped = true;
            entity.SetVelocity(0f);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
