using UnityEngine;

public abstract class EnemyBaseState : State
{   
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        Vector3 gravity = stateMachine.ForceReceiver.Movement;
        
        stateMachine.Controller.Move((motion + gravity) * deltaTime);
    }

    protected bool IsInChaseRange()
    {
        Vector3 myPosition = stateMachine.transform.position;
        Vector3 playerPosition = stateMachine.Player.transform.position;

        float distanceToPlayerSqr = (myPosition - playerPosition).sqrMagnitude;
        float playerChasingRangeSqr = stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;

        return distanceToPlayerSqr <= playerChasingRangeSqr;
    }

    protected void FacePlayer()
    {
        if(stateMachine.Player == null) { return; }

        Vector3 myPosition = stateMachine.transform.position;
        Vector3 playerPosition = stateMachine.Player.transform.position;

        Vector3 lookPosition = playerPosition - myPosition;
        lookPosition.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }
}
