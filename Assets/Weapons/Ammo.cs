using System;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetAmmo(AmmoType ammoType)
    {
        AmmoSlot currentAmmoSlot = GetAmmoSlot(ammoType);

        return currentAmmoSlot.ammoAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount)
    {
        AmmoSlot currentAmmoSlot = GetAmmoSlot(ammoType);

        currentAmmoSlot.ammoAmount += amount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot currentAmmoSlot = GetAmmoSlot(ammoType);

        if(currentAmmoSlot.ammoAmount <= 0) { return; }

        currentAmmoSlot.ammoAmount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }

}
