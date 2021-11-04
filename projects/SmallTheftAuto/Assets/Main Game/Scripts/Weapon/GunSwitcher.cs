using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    int _totalWeapons = 1;
    public int currentWeaponIndex;
    public GameObject[] guns;
    public GameObject GunHolder;
    public GameObject currentGun;
    
    void Start()
    {
        _totalWeapons = GunHolder.transform.childCount;
        guns = new GameObject[_totalWeapons];

        for (int i = 0; i < _totalWeapons; i++)
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
            if (currentWeaponIndex < _totalWeapons-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
        // Previous weapon
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
            }
            
        }
      
    }
}
