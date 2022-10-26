using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.PlayLocomotionBlendTree(CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer();

        MoveToPlayer(deltaTime);

        if(!IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }

        else if(IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackState(stateMachine));
            return;
        }

        stateMachine.AnimationHandler.SetLocomotionBlendTree(1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() 
    { 
        ResetNavMeshAgent();
    }

    private void ResetNavMeshAgent()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;

        Vector3 navMeshVelocity = stateMachine.Agent.desiredVelocity.normalized;
        Vector3 myVelocity = navMeshVelocity * stateMachine.MovementSpeed;

        Move(myVelocity, deltaTime);

        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }
}