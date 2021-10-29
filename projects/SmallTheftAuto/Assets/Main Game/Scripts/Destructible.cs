using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    //This means everything we want to be able to destroy, also can burn.
    //Everything that we want to just burn, will also get damaged. But not destroyed
    //Should remove those two interfaces because they are of no use
    
    [SerializeField] private int fireThreshold = 30;
    private bool hasBeenDestroyed = false;
    private Player player;
    private Building building;
    private IHaveHealth healthInterface;

    private GameManager gameManager;

    //Fire
    public GameObject firePrefab;
    private Vector3 fireOffset = new Vector3(0, 3, 0);
    private bool isBurning = false;
    private bool hasBurned;
    private int fireDamage = 5;
    private int fireDamageInterval = 1;
    private int fireMaxDuration = 10;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = GetComponent<Player>();
        building = GetComponent<Building>();
        healthInterface = GetComponent<IHaveHealth>();
        HasHealth();
    }

    private void Update()
    {
        if (HasHealth()) {
            if (healthInterface.Health <= 0 && !hasBeenDestroyed) {
                OnDeath();
                return;
            }

            if (healthInterface.Health <= fireThreshold) {
                if (!isBurning && !hasBurned)
                {
                    OnFire(); 
                }
            }
        }
    }

    private bool HasHealth() {
        if (healthInterface != null) {
            return true;
        }

        return false;
    }
    
    //Damagearea script should be implemented instead of tag-checking
    //Will continue working on it soon!
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Fire")) return;
        isBurning = true;
        StartCoroutine(TakeFireDamage());
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Fire")) return;
        isBurning = false;
        StopCoroutine(TakeFireDamage());
    }

    public void OnFire()
    {
        if (player == null)
        {
            GameObject fireClone = SpawnChild(firePrefab, fireOffset, Quaternion.identity);
            isBurning = true;
            StartCoroutine(ExtinguishFire(fireClone)); //This counts down from 10
            if (HasHealth())
            {
                StartCoroutine(TakeFireDamage()); // This deals damage every 3 seconds
            }
        }
    }

    private IEnumerator ExtinguishFire(GameObject fireClone)
    {
        yield return new WaitForSeconds(fireMaxDuration);
        Destroy(fireClone);
        isBurning = false;
        hasBurned = true;
    }

    private IEnumerator TakeFireDamage()
    {
        while (isBurning && healthInterface.Health != 0)
        {
            TakeDamage(fireDamage);
            yield return new WaitForSeconds(fireDamageInterval);
        }
    }
    
    private IEnumerator TakeWaterDamage()
    {
        while (isBurning && healthInterface.Health != 0)
        {
            TakeDamage(fireDamage);
            yield return new WaitForSeconds(fireDamageInterval);
        }
    }

    public GameObject SpawnChild(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;
    }

    public void TakeDamage(int damage)
    {
        healthInterface.Health -= damage;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
        if (hurtOnCrash != null)
        {
            TakeDamage(hurtOnCrash.DamageOnCrash);
            //Debug.Log($"{gameObject} have taken {hurtOnCrash.DamageOnCrash} damage from colliding with {other}");
        }
    }

    public void OnDeath()
    {
        Player player = GetComponent<Player>();
        if (player != null)
        {
            gameManager.Respawn();
            //gameManager.Pause();
            //Time.timeScale = 0.3f; //Slows down time
            //gameManager.RestartGame(); //We probably want to call another method here
        }
        
        Explosion explosion = GetComponent<Explosion>(); //Checks if the object has the Explosions script and then calls that script if it does have it.
        if (explosion != null) {
            explosion.Explode();
            Player playerIsInCar = GetComponentInChildren<Player>();
            if (playerIsInCar != null)
            {
                healthInterface.Health = 0;
            }
        }
        
        hasBeenDestroyed = true;
    }
}