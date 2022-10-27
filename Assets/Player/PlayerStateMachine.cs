using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(CharacterController), typeof(ForceReceiver))]
[RequireComponent(typeof(PlayerGunHandler))]
public class PlayerStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public PlayerGunHandler GunHandler { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 100f)] public float MouseSensitivity { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float MovementSpeed { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 10f)] public float JumpForce { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    private void OnEnable()
    {
        InputReader.FireEvent += HandleFire;
        InputReader.PrimaryGunEvent += HandlePrimaryGun;
        InputReader.SecondaryGunEvent += HandleSecondaryGun;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

    private void OnDisable()
    {
        InputReader.FireEvent -= HandleFire;
        InputReader.PrimaryGunEvent -= HandlePrimaryGun;
        InputReader.SecondaryGunEvent -= HandleSecondaryGun;
    }

    private void HandleFire()
    {
        GunHandler.ShootCurrentGun(MainCameraTransform);
    }

    private void HandlePrimaryGun()
    {
        GunHandler.ChoosePrimaryWeapon();
    }

    private void HandleSecondaryGun()
    {
        GunHandler.ChooseSecondaryWeapon();
    }
}
