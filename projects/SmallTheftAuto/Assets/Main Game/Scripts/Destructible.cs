using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int fireThreshold = 30;
    private int health;
    

    private int Health
    {
        set => health = Mathf.Clamp(value, 0, maxHealth);
        get => health;
    }

    public Destructible()
    {
        health = maxHealth;
    }
    

    private void Update()
    {
        if (Health <= fireThreshold)
        {
            if (Health <= 0)
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
        Health -= damage;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
        Debug.Log("Health is" + Health);
        if (hurtOnCrash != null)
        {
            
            TakeDamage(hurtOnCrash.DamageOnCrash);
            Debug.Log("I should have taken damage" + hurtOnCrash.DamageOnCrash);
            
        }
    }

    public void OnDeath()
    {
        Debug.Log("Destructible OnDeath");
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        
        if (explosion != null)
        {
            explosion.Explode();
        }

    }
}
