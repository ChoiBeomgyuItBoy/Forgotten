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

        FacePlayer(deltaTime);
        
        if(stateMachine.AnimationHandler.AnimationIsOver("Attack"))
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
        }
    }

    public override void Exit() { }
}
