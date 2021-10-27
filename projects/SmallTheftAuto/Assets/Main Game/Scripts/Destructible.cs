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
    private bool hasBeenDestroyed = false;
    private Vector3 fireOffset = new Vector3(0, 3, 0);

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
            if (Health <= 0 && !hasBeenDestroyed)
            {
                OnDeath(); // This get's called endlessly. -- Should be fixed with HasBeenDestroyed
                return;
            }

            if (!isOnFire)
            {
               OnFire(); 
            }
        }
    }

    public void OnFire()
    {
        Debug.Log(gameObject + "on fire");
        SpawnChild(firePrefab, fireOffset, Quaternion.identity);

        isOnFire = true;
        
        //Trigger fire animation
    }


    private void SpawnChild(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage called for " + damage + "Damage. Health is " + Health);
        Health -= damage;
        Debug.Log("Health is now " + Health);
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
        
        hasBeenDestroyed = true;
    }
}
