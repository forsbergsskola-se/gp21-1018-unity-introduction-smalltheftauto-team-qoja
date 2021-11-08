using System.Collections;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int fireThreshold = 30;
    [SerializeField] private GameObject firePrefab;
    
    protected IHaveHealth HealthInterface;
    protected bool HasDied;
    private Player _player;
    private Explosion _explosion;
    private bool _isBurning;
    private bool _hasBurned;
    
    private bool HasHealth()
    {
        return HealthInterface != null;
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        HealthInterface = GetComponent<IHaveHealth>();
        _explosion = GetComponent<Explosion>();
    }
    
    public virtual void Update()
    {
        if (HasHealth())
        {
            if (HealthInterface.Health <= 0 && !HasDied)
            {
                OnDeath();
                return;
            }

            if (HealthInterface.Health <= fireThreshold)
            {
                if (!_isBurning && !_hasBurned)
                {
                    OnFire(); 
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (_player == null) {
            IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
            if (hurtOnCrash != null)
            {
                //Taking damage from colliding with object that deals damage if you run into it
                TakeDamage(hurtOnCrash.DamageOnCrash);
            }
        }
    }
    
    public void TakeDamage(int damage)
    {
        HealthInterface.Health -= damage;
    }
    
    public IEnumerator TakeDamageOverTime(int damage, float interval)
    {
        while (HealthInterface.Health > 0)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(interval);
        }
    }
    
    public void OnFire()
    {
        Vector3 fireOffset = new Vector3(0, 3, 0);
        const int fireDamage = 5;
        const float fireDamageInterval = 1;
        
        //If the object is not a player, fire is spawned
        if (_player == null)
        {
            GameObject fireClone = SpawnFireAsChild(firePrefab, fireOffset, Quaternion.identity);
            _isBurning = true;
            
            StartCoroutine(ExtinguishFire(fireClone));
            
            if (HasHealth())
            {
                if (_isBurning)
                {
                    StartCoroutine(TakeDamageOverTime(fireDamage, fireDamageInterval));
                }
            }
        }
    }

    private IEnumerator ExtinguishFire(Object fireClone)
    {
        const int fireMaxDuration = 10;
        yield return new WaitForSeconds(fireMaxDuration);
        Destroy(fireClone);
        _isBurning = false;
        _hasBurned = true;
    }

    //Spawns a prefab as a child of a gameobject on desired position on parent
    private GameObject SpawnFireAsChild(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;
    }

    protected virtual void OnDeath()
    {
        if (_explosion != null) {
            _explosion.Explode();
            KillPlayerInExplosion();
            _explosion.DisableAfterExplosion();
        }
        
        HasDied = true;
    }

    //Check if a player is in the exploding object, if yes player is killed
    private void KillPlayerInExplosion()
    {
        
        // Why do you need a loop and array here? 
        
        Player[] playerArray = transform.GetComponentsInChildren<Player>(true);
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i] != null)
            {
                KillPlayer(playerArray[i]);
            }
        }
    }

    //If player dies inside car it still exists as a child of car and therefore do not respawn correctly.
    //To fix this we exit the car right after death to no longer have it a child of the car. // Understandable. 
    private void KillPlayer(Player playerInCar)
    {
        Vehicle vehicle =  playerInCar.GetComponentInParent<Vehicle>();
        playerInCar.Health = 0;
        if (vehicle != null)
        {
            vehicle.ExitCar(vehicle.playerOffset);
        }
    }
}