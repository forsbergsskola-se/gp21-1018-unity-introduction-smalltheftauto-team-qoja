using UnityEngine;

public class ProjectileQL : MonoBehaviour
{
    float speed = 5f;

    public int Power { get; }

    public ProjectileQL(int value)
    {
        Power = value;
    }

    private Vector3 shootDirection;
    
    void Setup(Vector3 shootDirection)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    public void FireProjectile(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        VehicleQL vehicle = other.collider.gameObject.GetComponent<VehicleQL>();
        if (vehicle)
        {
            vehicle.CarTakeDamage(Power);
        }
        Destroy(this.gameObject);
    }
}
