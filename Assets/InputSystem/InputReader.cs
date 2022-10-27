using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public Vector2 MouseValue { get; private set; }

    public event Action JumpEvent;
    public event Action FireEvent;
    public event Action PrimaryGunEvent;
    public event Action SecondaryGunEvent;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();

        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) 
    { 
        MouseValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        JumpEvent?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        FireEvent?.Invoke();
    }

    public void OnPrimaryWeapon(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        PrimaryGunEvent?.Invoke();
    }

    public void OnSecondaryWeapon(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        SecondaryGunEvent?.Invoke();
    }
}
