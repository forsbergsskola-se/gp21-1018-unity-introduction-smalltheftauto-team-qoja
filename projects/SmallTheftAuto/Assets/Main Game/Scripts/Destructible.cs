using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    //This means everything we want to be able to destroy, also can burn.
    //Everything that we want to just burn, will also get damaged. But not destroyed
    
    [SerializeField] private int maxHealth = 1000;
    [SerializeField] private int fireThreshold = 30;
    private int health;
    public GameObject firePrefab;
    
    private bool hasBeenDestroyed = false;
    private Player player;
    private Building building;
    
    //Fire
    private Vector3 fireOffset = new Vector3(0, 3, 0);
    private bool isBurning = false;
    private bool hasBurned;
    private int fireDamage = 5;
    private int fireDamageInterval = 1;
    private int fireMaxDuration = 10;
    
    private int Health
    {
        set => health = Mathf.Clamp(value, 0, maxHealth);
        get => health;
    }

    public Destructible()
    {
        Health = maxHealth;
    }

    private void Start()
    {
        player = GetComponent<Player>();
        building = GetComponent<Building>();
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
            if (!isBurning && !hasBurned) //!isOnFire and not player spawn animation
            {
               OnFire(); 
            }
        }

        //If gameobject is player and isInfire (set from bool in ontriggerenter, call ImInFire rename takeFireDamage
        //Edit so car can take also use takeFireDamage
        //FireDamage stops after 10 sec but car can still explode if it reaches 0
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
       if (other.gameObject.CompareTag("Fire"))
       {
           Debug.Log($"{gameObject} is in fire");
           isBurning = true;
           StartCoroutine(TakeFireDamage());
           
       }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            isBurning = false;
            StopCoroutine(TakeFireDamage());
            Debug.Log($"{gameObject} left the fire");
        }
    }

    public void OnFire()
    {
        if (player == null)
        {
            Debug.Log(gameObject + "Starts burning");
            Debug.Log($"Fire should spawn on {gameObject}");
            GameObject fireClone = SpawnChild(firePrefab, fireOffset, Quaternion.identity);
            isBurning = true;
            StartCoroutine(ExtinguishFire(fireClone)); //This counts down from 10
            StartCoroutine(TakeFireDamage()); // This deals damage every 3 seconds
            
        }
        //If gameobject has building script increase fire start size

        
    }

    private IEnumerator ExtinguishFire(GameObject fireClone)
    {
        Debug.Log($"{gameObject} Fire countdown started");
        yield return new WaitForSeconds(fireMaxDuration);
        Destroy(fireClone);
        Debug.Log(firePrefab + "Is supposed to get destroyed");
        isBurning = false;
        hasBurned = true;
    }

    //Possibly needed to change name of this method
    private IEnumerator TakeFireDamage() //Takes x amount of damage every y seconds
    {
        
        while (isBurning)
        {
            Debug.Log($"{gameObject} Will take {fireDamage} damage");
            TakeDamage(fireDamage);
            Debug.Log($"{gameObject} has taken {fireDamage} damage");
            yield return new WaitForSeconds(fireDamageInterval);
        }
        
    }


    private GameObject SpawnChild(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;
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
        Player player = GetComponent<Player>();
        if (player != null)
        {
            GameManager.instance.RestartGame();
        }
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        if (explosion != null) {
            Debug.Log($"{gameObject} is exploding");
            explosion.Explode();
            Player playerIsInCar = GetComponentInChildren<Player>();
            if (playerIsInCar != null)
            {
                playerIsInCar.Health = 0;
            }
        }
        
        hasBeenDestroyed = true;
    }
}
