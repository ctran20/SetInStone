using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    [SerializeField] GameObject redIcon;
    [SerializeField] GameObject yellowIcon;
    [SerializeField] GameObject blueIcon;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        
        if(currentWeapon == 0){
            redIcon.SetActive(true);
            yellowIcon.SetActive(false);
            blueIcon.SetActive(false);
        }
        else if(currentWeapon == 1){
            redIcon.SetActive(false);
            yellowIcon.SetActive(true);
            blueIcon.SetActive(false);
        }
        else{
            redIcon.SetActive(false);
            yellowIcon.SetActive(false);
            blueIcon.SetActive(true);
        }

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon){
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0) {
            currentWeapon = (currentWeapon + 1) % 3;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        ;
    }
}
