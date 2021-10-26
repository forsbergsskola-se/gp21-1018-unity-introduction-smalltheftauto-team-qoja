using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int fireThreshold = 30;
    private int health;
    public GameObject firePrefab;
    private bool isOnFire = false;
    

    private int Health
    {
        set => health = Mathf.Clamp(value, 0, maxHealth);
        get => health;
    }

    public Destructible()
    {
        health = maxHealth;
    }

    public void Start()
    {
        
        //firePrefab = Resources.Load("Prefabs/Effects/Fire", GameObject) as GameObject;
    }

    private void Update()
    {
        
        if (Health <= fireThreshold)
        {
            if (Health <= 0)
            {
                OnDeath(); // This get's called endlessly.
                return;
            }

            if (!isOnFire)
            {
               OnFire(); 
            }
            
        }
        
    }

    public void OnFire() {
        
        Debug.Log(gameObject + "on fire");
        (Instantiate (firePrefab, transform.position, transform.rotation) as GameObject).transform.parent = gameObject.transform;
        //Fire dies after a certain time
        isOnFire = true;


        //Trigger fire animation
        
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
        
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        
        if (explosion != null)
        {
            explosion.Explode();
        }

    }
}
