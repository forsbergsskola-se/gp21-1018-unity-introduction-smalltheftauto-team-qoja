using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // This is the point that we instantiate the prefab bullet from
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletNumber = 7;
    public int maxBullet;
    [SerializeField] private float fireRate = 10f;
    private float _lastFired;
    [SerializeField] private float reloadTime = 1.5f;
    
    void Update()
    {
        if (this.name == "pistol1")
        {
            maxBullet = 7;
            if (Input.GetButtonDown("Fire1") && bulletNumber > 0)
            {
                Shoot();
            }
        }
        if (this.name == "smg2")
        {
            maxBullet = 30;
            if (Input.GetButton("Fire1") && bulletNumber > 0)
            {
                // Creating interval between instantiated bullets
                if (Time.time - _lastFired > 1/fireRate) 
                {
                    _lastFired = Time.time;
                    Shoot();
                }
            }
        }

        //Reload function with delay - Reload time is adjustable on the scene
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Invoke("ReloadGun",reloadTime);
        }
    }

    private void ReloadGun()
    {
        bulletNumber = maxBullet;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        bulletNumber--;
    }
}
