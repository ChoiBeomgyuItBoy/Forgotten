using System.Collections;
using UnityEngine;

public class PlayerGunHandler : MonoBehaviour
{
    private Gun currentGun;
    private const int InventorySize = 2;

    [SerializeField] private Transform gunPlacer;
    [SerializeField] private Gun primaryGun;
    [SerializeField] private Gun secondaryGun;

    private GameObject[] pool;

    private bool canShoot = true;

    private void OnEnable()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[InventorySize];

        pool[0] = primaryGun?.InstantiateGun(gunPlacer, gunPlacer);
        pool[1] = secondaryGun?.InstantiateGun(gunPlacer, gunPlacer);

        pool[0]?.SetActive(false);
        pool[1]?.SetActive(false);
    }

    public void ChoosePrimaryGun()
    {
        if(primaryGun == null) { return; }

        currentGun = primaryGun;

        pool[0]?.SetActive(true);
        pool[1]?.SetActive(false);
    }

    public void ChooseSecondaryGun()
    {
        if(secondaryGun == null) { return; }

        currentGun = secondaryGun;

        pool[0]?.SetActive(false);
        pool[1]?.SetActive(true);        
    }

    public void DisableGuns()
    {
        if(primaryGun == null) { return; }
        if(secondaryGun == null) { return; }

        currentGun = null;

        pool[0]?.SetActive(false);
        pool[1]?.SetActive(false); 
    }

    public void ShootCurrentGun(Transform center)
    {
        if(currentGun == null) { return; }

        if(canShoot) 
        { 
            currentGun?.Shoot(center);
            currentGun?.TryPlayVFX();
            StartCoroutine(CanShoot(currentGun.ShootingDelay));
        }
    }

    private IEnumerator CanShoot(float time)
    {
        canShoot = false;

        yield return new WaitForSeconds(time);

        canShoot = true;
    }
}
