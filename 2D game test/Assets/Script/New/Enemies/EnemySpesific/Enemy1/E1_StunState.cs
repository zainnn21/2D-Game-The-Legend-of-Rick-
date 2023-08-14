using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_StunState : StuntState
{
    private Enemy1 enemy;
    public E1_StunState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_StuntState stateData,Enemy1 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        entity.ResetStunResistence();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isStuntTimeOver)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(enemy.meleeAttackState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.chargeState);
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImediately(true);
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
