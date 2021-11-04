using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletNumber = 7;
    public int maxBullet;
    [SerializeField] private float fireRate = 10f;
    private float lastFired;
    [SerializeField] private float reloadTime = 1.5f;
    

    // Update is called once per frame
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
                if (Time.time - lastFired > 1/fireRate)
                {
                    lastFired = Time.time;
                    Shoot();
                }
            }
        }

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
