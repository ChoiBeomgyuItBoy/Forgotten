using System.Collections;
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
    [field: SerializeField] [field: Range(0.1f, 10f)] public float JumpForce { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] private float FreeMovementSpeed { get; set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] private float WithGunMovementSpeed { get; set; }

    public Transform MainCameraTransform { get; private set; }

    public float CurrentSpeed { get; private set; }

    private void OnEnable()
    {
        InputReader.FireEvent += HandleFire;
        InputReader.PrimaryGunEvent += HandlePrimaryGun;
        InputReader.SecondaryGunEvent += HandleSecondaryGun;
        InputReader.WithoutWeaponEvent += HandleWithoutGun;
    }

    private void Start()
    {
        CurrentSpeed = FreeMovementSpeed;

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
        InputReader.WithoutWeaponEvent -= HandleWithoutGun;
    }

    private void HandleFire()
    {
        GunHandler.ShootCurrentGun(MainCameraTransform);
    }

    private void HandlePrimaryGun()
    {
        CurrentSpeed = WithGunMovementSpeed;
        
        GunHandler.ChoosePrimaryGun();
    }

    private void HandleSecondaryGun()
    {
        CurrentSpeed = WithGunMovementSpeed;

        GunHandler.ChooseSecondaryGun();
    }

    private void HandleWithoutGun()
    {
        CurrentSpeed = FreeMovementSpeed;

        GunHandler.DisableGuns();
    }
}
