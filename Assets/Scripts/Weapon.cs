using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 300f;
    [SerializeField] float damage = 35f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float coolDownTime = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool coolDown = false;

    private void OnEnable()
    {
        coolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();    

        if(Input.GetMouseButton(0) && coolDown == false){
            StartCoroutine(Shoot());
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("Shooting", false);
        }
        
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        coolDown = true;
        GetComponent<Animator>().SetTrigger("Shot");
        GetComponent<Animator>().SetBool("Shooting", true);

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            if (ammoType == AmmoType.BlueJuice)
            {
                AudioManager.PlaySound("blaster", 0.15f, 3);
            }
            else if (ammoType == AmmoType.YellowJuice)
            {
                AudioManager.PlaySound("blaster", 0.25f, 0.3f);
                AudioManager.PlaySound("explosion", 0.1f, 1);
            }
            else
            {
                AudioManager.PlaySound("blaster", 0.15f, 1.8f);

            }

            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        else
        {
            AudioManager.PlaySound("empty_ammo", 0.2f, 2);
        }

        yield return new WaitForSeconds(coolDownTime);
        coolDown = false;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);

    }
}
