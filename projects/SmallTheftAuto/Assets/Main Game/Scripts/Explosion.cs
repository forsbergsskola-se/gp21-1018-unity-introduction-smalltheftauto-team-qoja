using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 3.0f;
    [SerializeField] private int _damage = 50;

    protected void Start()
    {
        Explode();
    }

    private void Explode() {
        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in nearbyColliders) {
            Destructible destructible = collider.gameObject.GetComponent<Destructible>();
            if (destructible != null) {
                destructible.InflictDamage(_damage);
            }

            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                // Add a force to the rigidbody away from the explosion
            }
        }
    }
}
