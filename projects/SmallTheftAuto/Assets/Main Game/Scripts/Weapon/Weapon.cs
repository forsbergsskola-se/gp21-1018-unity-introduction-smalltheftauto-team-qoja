using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletNumber = 7;
    public int maxBullet;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float reloadTime = 1.5f;
    private float _lastFired;
    
    
    private void Update()
    {
        GunType();
        
        //Reload function with delay - Reload time is adjustable on the scene
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Invoke(nameof(ReloadGun),reloadTime);
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

    void GunType()
    {
        if (name == "pistol1")
        {
            maxBullet = 7;
            if (Input.GetButtonDown("Fire1") && bulletNumber > 0)
            {
                Shoot();
            }
        }
        if (name == "smg2")
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
    }
}
