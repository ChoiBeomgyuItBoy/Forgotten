using UnityEngine;

public abstract class RevolverBaseState : State
{
    protected RevolverStateMachine stateMachine;

    public RevolverBaseState(RevolverStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
