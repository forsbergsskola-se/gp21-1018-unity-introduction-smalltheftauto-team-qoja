using System.Collections;
using UnityEngine;


public class Destructible : MonoBehaviour, IBurnable, IDamageable //Should remove those two interfaces because they are of no use
{
    [SerializeField] private int fireThreshold = 30;
    [SerializeField] GameObject firePrefab;
    
    private Player player;
    private IHaveHealth healthInterface;
    private Explosion explosion;
    
    private bool hasDied;
    private bool isBurning;
    private bool hasBurned;

    private void Start()
    {
        player = GetComponent<Player>();
        healthInterface = GetComponent<IHaveHealth>();
        explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (HasHealth()) {
            if (healthInterface.Health <= 0 && !hasDied) {
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
    
    public void TakeDamage(int damage)
    {
        healthInterface.Health -= damage;
    }

    public IEnumerator TakeDamageOverTime(int damage, float interval)
    {
        while (healthInterface.Health > 0)
        {
            TakeDamage(damage);
            yield return new WaitForSeconds(interval);
        }
    }

    public void OnFire()
    {
        int fireDamage = 5;
        float fireDamageInterval = 1;
        Vector3 fireOffset = new Vector3(0, 3, 0);
        
        if (player == null)
        {
            GameObject fireClone = SpawnChild(firePrefab, fireOffset, Quaternion.identity);
            isBurning = true;
            StartCoroutine(ExtinguishFire(fireClone));
            
            if (HasHealth())
            {
                if (isBurning)
                {
                    StartCoroutine(TakeDamageOverTime(fireDamage, fireDamageInterval));
                }
            }
        }
    }

    private IEnumerator ExtinguishFire(GameObject fireClone)
    {
        int fireMaxDuration = 10;
        yield return new WaitForSeconds(fireMaxDuration);
        Destroy(fireClone);
        isBurning = false;
        hasBurned = true;
    }

    public GameObject SpawnChild(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IHurtOnCrash hurtOnCrash = other.gameObject.GetComponent<IHurtOnCrash>();
        if (hurtOnCrash != null)
        {
            TakeDamage(hurtOnCrash.DamageOnCrash);
        }
    }

    public void OnDeath()
    {
        if (explosion != null) {
            explosion.Explode();
            KillPlayerInExplosion();
            explosion.DisableAfterExplosion();
        }
        
        hasDied = true;
    }

    private void KillPlayerInExplosion()
    {
        Player[] allChildren = transform.GetComponentsInChildren<Player>(true);
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (allChildren[i] != null)
            {
                KillPlayer(allChildren[i]);
            }
        }
    }

    private void KillPlayer(Player playerInCar)
    {
        playerInCar.Health = 0;
    }
}