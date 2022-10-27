using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.AnimationHandler.PlayRandomAttack();
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer();
        
        if(stateMachine.AnimationHandler.AnimationIsOver())
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
        }
    }

    public override void Exit() { }
}
