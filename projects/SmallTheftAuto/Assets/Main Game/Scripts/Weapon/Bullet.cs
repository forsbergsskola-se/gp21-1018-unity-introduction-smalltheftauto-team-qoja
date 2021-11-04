using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHurtOnCrash
{

    public float bulletSpeed = 30000000f;
    public Rigidbody2D bulletRb;
    public int bulletDamage = 10;
    public int DamageOnCrash => bulletDamage;
    [SerializeField] private float timeActiveBullet = 2f;
    
    
    void Start()
    {
        bulletRb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destructible destructible = other.gameObject.GetComponentInParent<Destructible>();
        if (destructible != null)
        {
           destructible.TakeDamage(DamageOnCrash); 
        }

        Destroy(gameObject);
    }

    void Update()
    {
        // Destroying the game object prefab bullet after x seconds
        Invoke(nameof(DestroyBullet), timeActiveBullet);
    }
    
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
