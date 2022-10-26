using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    private void Start()
    {
        SwitchState(new PlayerFreeLookState(this));
    }
}
