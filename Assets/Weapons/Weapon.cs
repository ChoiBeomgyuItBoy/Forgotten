using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform muzzle;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private float shootDistance;
    [SerializeField] private float shootDamage;
    [SerializeField] private float shootDelay;

    private Transform mainCameraTransform;

    private bool canShoot = true;

    private void OnEnable()
    {
        inputReader.FireEvent += HandleFire;
        playerHealth.onPlayerDead += HandePlayerDead;
    }

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void OnDisable()
    {
        inputReader.FireEvent -= HandleFire;
        playerHealth.onPlayerDead -= HandePlayerDead;
    }

    private IEnumerator HandleFire()
    {
        if(!canShoot) { yield break; }

        canShoot = false;

        if(ammoSlot.GetAmmo(ammoType) <= 0) { yield break; }

        HandleRayCastHit();

        ammoSlot.ReduceCurrentAmmo(ammoType);

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    private void PlayMuzzleFlashVFX()
    {
        Instantiate(muzzleFlashVFX, muzzle);
    }

    private void PlayHitVFX(RaycastHit hit)
    {
        Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
    }

    private void HandleRayCastHit()
    {
        RaycastHit hit = GetRaycastHit();

        PlayMuzzleFlashVFX();

        if(hit.transform == null) { return; }

        if(hit.transform.GetComponent<PlayerStateMachine>()) { return; }
        
        if(hit.transform.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.TakeDamage(shootDamage);
        }

        PlayHitVFX(hit);
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

    private void HandePlayerDead()
    {
        inputReader.FireEvent -= HandleFire;
    }

}
