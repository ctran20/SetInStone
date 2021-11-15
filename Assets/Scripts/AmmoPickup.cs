using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 20;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            AudioManager.PlaySound("collect", 0.1f, 1f);
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }


}
