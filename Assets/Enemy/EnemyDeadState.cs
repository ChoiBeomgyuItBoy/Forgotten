using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Controller.enabled = false;
        stateMachine.AnimationHandler.PlayDead();
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.AnimationHandler.AnimationIsOver("Death")) 
        {
            stateMachine.DestroyMyself(); 
        }   
    }

    public override void Exit() { }
}
