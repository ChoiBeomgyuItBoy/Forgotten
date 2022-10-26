using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private float xRotation = 0f;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() { }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.MovementSpeed, deltaTime);

        MouseRotation(stateMachine.InputReader.MouseValue, deltaTime);
    }

    public override void Exit() { }

    private Vector3 CalculateMovement()
    {
        Vector3 xMovement = stateMachine.InputReader.MovementValue.x * stateMachine.transform.right;
        Vector3 zMovement = stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward;

        return xMovement + zMovement;
    }

    private void MouseRotation(Vector2 mouseMovement, float deltaTime)
    {
        if(mouseMovement == Vector2.zero) { return; }

        float mouseX = mouseMovement.x * stateMachine.MouseSensitivity * deltaTime;
        float mouseY = mouseMovement.y * stateMachine.MouseSensitivity * deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        stateMachine.transform.Rotate(Vector3.up * mouseX);
        stateMachine.MainCameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}