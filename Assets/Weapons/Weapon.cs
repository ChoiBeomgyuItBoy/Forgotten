using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform muzzle;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float shootDistance;
    [SerializeField] private float shootDamage;

    private Transform mainCameraTransform;

    private void Start()
    {
        inputReader.FireEvent += HandleFire;
        playerHealth.onPlayerDead += HandePlayerDead;

        mainCameraTransform = Camera.main.transform;
    }

    private void OnDisable()
    {
        inputReader.FireEvent -= HandleFire;
        playerHealth.onPlayerDead -= HandePlayerDead;
    }

    private void HandleFire()
    {
        PlayMuzzleFlashVFX();
        
        RaycastHit hit = GetRaycastHit();

        if(hit.transform == null) { return; }

        if(hit.transform.GetComponent<PlayerStateMachine>()) { return; }
        
        if(hit.transform.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            health.TakeDamage(shootDamage);
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

    private void HandePlayerDead()
    {
        Destroy(this);
    }

}
