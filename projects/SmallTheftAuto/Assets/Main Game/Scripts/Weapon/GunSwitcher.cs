using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    
    public GameObject[] guns;
    public GameObject GunHolder;
    public GameObject currentGun;
    
    void Start()
    {
        totalWeapons = GunHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = GunHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;

    }

    void Update()
    {
        // Next Weapon
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeaponIndex < totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
        
        
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
            //SwitchGuns();
        //}
    }

    void SwitchGuns()
    {
        foreach (Transform GunHolder in transform)
        {
            GunHolder.gameObject.SetActive(!GunHolder.gameObject.activeSelf);
        }
    }
}
