using UnityEngine;

[RequireComponent(typeof(RevolverAnimationHandler))]
public class RevolverStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public GameObject ShootVFX { get; private set; }
    [field: SerializeField] public Transform ShootVFXPlacer { get; private set; }
    [field: SerializeField] public GameObject HitVFX { get; private set; }
    [field: SerializeField] public RevolverAnimationHandler AnimationHandler { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 100f)] public float ShootRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 10f)] public float ShootDelay { get; private set; }
    [field: SerializeField] [field: Range(1, 100)] public int ShootDamage { get; private set; }
    [field: SerializeField] [field: Range(1, 100)] public int MaxBullets { get; private set; }
    [field: SerializeField] public int CurrentBullets { get; set; }

    public Transform MainCameraTransform { get; private set; }
  
    private void Start()
    {
        CurrentBullets = MaxBullets;

        MainCameraTransform = Camera.main.transform;

        SwitchState(new RevolverIdleState(this));
    }

    public void PlayShootVFX()
    {
        Instantiate(ShootVFX, ShootVFXPlacer);
    }

    public void PlayHitVFX(RaycastHit hit)
    {
        Instantiate(HitVFX, hit.point, Quaternion.LookRotation(hit.normal));
    }
}
