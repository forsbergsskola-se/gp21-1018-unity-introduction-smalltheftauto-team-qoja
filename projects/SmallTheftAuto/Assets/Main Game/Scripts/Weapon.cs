using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletNumber = 7;
    public int maxBullet = 7;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletNumber > 0)
        {
            Shoot();
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
