using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IHurtOnCrash
{

    public float bulletSpeed = 30000000f;
    public Rigidbody2D bulletRb;

    public int bulletDamage = 10;
    public int DamageOnCrash => bulletDamage; //Added this, but currently not doing damage anyhows.
    // Start is called before the first frame update
    void Start()
    {
        bulletRb.velocity = transform.right * bulletSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Destructible destructible = other.gameObject.GetComponentInParent<Destructible>();
        if (destructible != null)
        {
           destructible.TakeDamage(DamageOnCrash); 
        }
        
        
        
        Destroy(gameObject);
    }

    void Update()
    {
        Invoke("DestroyBullet", 2f);
    }
    
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
