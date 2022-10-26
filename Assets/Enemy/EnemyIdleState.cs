using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.PlayLocomotionBlendTree(CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer();

        if(IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
            return;
        }

        stateMachine.AnimationHandler.SetLocomotionBlendTree(0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() { }
}
