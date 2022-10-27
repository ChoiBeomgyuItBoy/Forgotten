using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    [field: SerializeField] public GameObject GunModel { get; private set; }
    [field: SerializeField] public string GunName { get; private set; }
    [field: SerializeField] public int GunDamage { get; private set; }
    [field: SerializeField] public float ShootingRange { get; private set; } = 100f;
    [field: SerializeField] public float ShootingDelay { get; private set; }

    public ParticleSystem GunVFX { get; private set; }

    public void TryPlayVFX()
    {
        foreach(Transform child in GunModel.transform)
        {
            GunVFX = child.GetComponent<ParticleSystem>();

            if(GunVFX != null)
            {
                Debug.Log("Playing Particle System");
                GunVFX.Play();
                return;
            }
        }
    }

    public void Shoot(Transform center)
    {
        RaycastHit hit;
        
        Physics.Raycast(center.position, center.forward, out hit, ShootingRange);

        if(hit.transform == null) { return; }

        if(hit.transform.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(GunDamage);
        }
    }

    public GameObject InstantiateGun(Transform spawnPosition, Transform parent)
    {
        if(GunModel == null) { return null; }

        GameObject gun = Instantiate(GunModel, spawnPosition.position, Quaternion.identity);

        gun.transform.parent = parent;

        return gun;
    }
}
