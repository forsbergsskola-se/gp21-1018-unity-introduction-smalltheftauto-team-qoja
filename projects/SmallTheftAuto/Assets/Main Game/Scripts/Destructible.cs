using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    [SerializeField] private int health = 100;
    [SerializeField] private int fireThreshold = 30;


    private void Update()
    {
        if (health <= fireThreshold)
        {
            if (health <= 0)
            {
                OnDeath();
                return;
            }
            
            OnFire();
        }
        
    }

    public void OnFire() {
        Debug.Log(gameObject + "on fire");
        //Trigger fire animation
        //Fire dies after a certain time
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
        Debug.Log("Health is" + health);
        if (hurtOnCrash != null)
        {
            
            TakeDamage(hurtOnCrash.DamageOnCrash);
            Debug.Log("I should have taken damage" + hurtOnCrash.DamageOnCrash);
            
        }
    }

    public void OnDeath()
    {
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        
        if (explosion != null)
        {
            explosion.Explode();
        }
        
    }
}
