using System.Collections.Generic;
using UnityEngine;

public class PlayerGunHandler : MonoBehaviour
{
    private Gun currentGun;
    private const int InventorySize = 2;

    [SerializeField] private Transform primaryGunPlacer;
    [SerializeField] private Transform secondaryGunPlacer;

    [SerializeField] private Gun primaryGun;
    [SerializeField] private Gun secondaryGun;

    private GameObject[] pool;

    private void OnEnable()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[InventorySize];

        pool[0] = primaryGun?.InstantiateGun(primaryGunPlacer, primaryGunPlacer);
        pool[1] = secondaryGun?.InstantiateGun(secondaryGunPlacer, secondaryGunPlacer);

        pool[0]?.SetActive(false);
        pool[1]?.SetActive(false);
    }

    public void ChoosePrimaryWeapon()
    {
        if(primaryGun == null) { return; }

        currentGun = primaryGun;

        pool[0]?.SetActive(true);
        pool[1]?.SetActive(false);
    }

    public void ChooseSecondaryWeapon()
    {
        if(secondaryGun == null) { return; }

        currentGun = secondaryGun;

        pool[0]?.SetActive(false);
        pool[1]?.SetActive(true);        
    }

    public void ShootCurrentGun(Transform center)
    {
        currentGun?.Shoot(center);
    }
}
