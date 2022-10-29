using UnityEngine;

public class RevolverIdleState : RevolverBaseState
{
    public RevolverIdleState(RevolverStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.TransitionToLocomotion();
        stateMachine.InputReader.FireEvent += HandleFire;
    }

    public override void Tick(float deltaTime) 
    { 
        if(stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.AnimationHandler.PlayIdle(deltaTime);
        }
        else
        {
            stateMachine.AnimationHandler.PlayWalk(deltaTime);
        }
    }

    public override void Exit() 
    {
        stateMachine.InputReader.FireEvent -= HandleFire;
    }

    private void HandleFire()
    {
        if(stateMachine.CurrentBullets <= 0) { return; }

        stateMachine.SwitchState(new RevolverShootState(stateMachine, stateMachine.ShootDelay));
    }
}
