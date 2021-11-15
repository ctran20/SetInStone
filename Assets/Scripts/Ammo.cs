using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount)
    {
        if(ammoType == AmmoType.Health){
            player.Heal(amount);
        }
        else{
            GetAmmoSlot(ammoType).ammoAmount += amount;
        }
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType){
        foreach(AmmoSlot slot in ammoSlots){
            if(slot.ammoType == ammoType){
                return slot;
            }
        }
        return null;
    }
}
