using UnityEngine;

public class Bullet : MonoBehaviour, IHurtOnCrash
{
    public Rigidbody2D bulletRb;
    public float bulletSpeed = 30000000f;
    public int bulletDamage = 10;
    [SerializeField] private float rangeOfWeapon = 2f;
    public int DamageOnCrash => bulletDamage;

    void Start()
    {
        bulletRb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destructible destructible = other.gameObject.GetComponentInParent<Destructible>();
        
        if (destructible != null)
        {
           destructible.TakeDamage(DamageOnCrash); 
        }

        Destroy(gameObject);
    }

    void Update()
    {
        // Destroying the bullet after rangeOfWeapon in seconds
        Invoke(nameof(DestroyBullet), rangeOfWeapon);
    }
    
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
