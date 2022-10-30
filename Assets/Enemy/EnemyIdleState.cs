using System;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.TransitionToLocomotion();
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer(deltaTime);

        if(IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
            return;
        }

        stateMachine.AnimationHandler.PlayIdle(deltaTime);
    }

    public override void Exit() { }
}
