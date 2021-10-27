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
                OnDeath();
                return;
            }

            // if gameobject is player and is in fire (ontriggerenter) take damage but don't get caught on fire
            // to clean up so the player don't have to know if it should be damaged
            if (!isOnFire) //!isOnFire and not player spawn animation
            {
               OnFire(); 
            }
        }
        //If gameobject is player and isInfire (set from bool in ontriggerenter, call ImInFire rename takeFireDamage
        //Edit so car can take also use takeFireDamage
        //FireDamage stops after 10 sec but car can still explode if it reaches 0
    }

    public void OnFire()
    {
        Debug.Log(gameObject + "on fire");
        SpawnChild(firePrefab, fireOffset, Quaternion.identity);
        Debug.Log($"Fire should spawn on {gameObject}");
        //If gameobject has building script increase fire start size

        isOnFire = true;
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
        Debug.Log($"TakeDamage is called on {gameObject} for {damage} damage");
        Health -= damage;
        Debug.Log($"Health of {gameObject} is now {Health}");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
        if (hurtOnCrash != null)
        {
            
            TakeDamage(hurtOnCrash.DamageOnCrash);
            Debug.Log($"{gameObject} have taken {hurtOnCrash.DamageOnCrash} damage from colliding with {other}");
            
        }
    }

    public void OnDeath()
    {
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        if (explosion != null) {
            Debug.Log($"{gameObject} is exploding");
            explosion.Explode();
        }
        
        hasBeenDestroyed = true;
    }
}
