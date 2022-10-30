using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float shootDistance;
    [SerializeField] private int shootDamage;
    [SerializeField] private InputReader inputReader;

    private Transform mainCameraTransform;

    private void Start()
    {
        inputReader.FireEvent += HandleFire;
        mainCameraTransform = Camera.main.transform;
    }

    private void OnDisable()
    {
        inputReader.FireEvent -= HandleFire;
    }

    private void HandleFire()
    {
        PlayMuzzleFlashVFX();
        
        RaycastHit hit = GetRaycastHit();

        if(hit.transform == null) { return; }

        if(hit.transform.GetComponent<PlayerStateMachine>()) { return; }
        
        if(hit.transform.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(shootDamage);
        }

        PlayHitVFX(hit);
    }

    private void PlayMuzzleFlashVFX()
    {
        Instantiate(muzzleFlashVFX, muzzle);
    }

    private void PlayHitVFX(RaycastHit hit)
    {
        Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
    }

    private RaycastHit GetRaycastHit()
    {
        RaycastHit hit;

        Vector3 origin = mainCameraTransform.position;
        Vector3 direction = mainCameraTransform.forward;
        float maxDistance = shootDistance;

        Physics.Raycast(origin,direction, out hit, maxDistance);

        return hit;
    }
}
