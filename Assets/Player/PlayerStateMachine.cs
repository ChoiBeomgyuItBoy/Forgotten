using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(CharacterController), typeof(ForceReceiver))]
public class PlayerStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 100f)] public float MouseSensitivity { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 10f)] public float JumpForce { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float FreeMovementSpeed { get; set; }

    public Transform MainCameraTransform { get; private set; }

    private void Start()
    {
        PlayerHealth.onPlayerDead += HandleDead;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDead -= HandleDead;
    }

    private void HandleDead()
    {
        SwitchState(new PlayerDeadState(this));
    }
}
