using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletNumber = 30;
    public int maxBullet = 30;
    private float fireRate = 10f;
    private float lastFired;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && bulletNumber > 0)
        {
            if (Time.time - lastFired > 1/fireRate)
            {
                lastFired = Time.time;
                Shoot();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletNumber = maxBullet;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletNumber--;
    }
}
