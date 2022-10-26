using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() { }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Attack");

        stateMachine.SwitchState(new EnemyChaseState(stateMachine));
    }

    public override void Exit() { }
}
