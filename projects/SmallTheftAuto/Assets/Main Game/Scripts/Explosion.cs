using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 20.0f;
    [SerializeField] private int explosionDamage = 50;

    protected void Start()
    {
        Debug.Log("I am awake");
        Explode();
    }

    public void Explode() {
        //Stores colliders that are in explosion radius in an array
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        //Goes through the array and check if the gameobject of the collider has a burnable script component
        foreach (Collider2D collider in nearbyColliders) {
            
            IBurnable burnable = collider.gameObject.GetComponent<IBurnable>();
            burnable?.OnFire();
            
            //*****Added this so we can reference TakeDamage in destructable aswell, could also just replace the Iburnable check too in that case, but we'll talk about it tomorrow. Does not fully work right now tho*****
            //**//
            Destructible destructible = collider.gameObject.GetComponentInParent<Destructible>();
            if (destructible != null)
            {
                Debug.Log("I will deal" + explosionDamage + "Damage" );
                destructible.TakeDamage(explosionDamage);
                Debug.Log("I am supposed to have dealt" + explosionDamage + "Damage" );
            }
            else if (destructible == null)
            {
                Debug.Log("This message should not be seen");
            }
            //**//

            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                // Add a force to the rigidbody away from the explosion
            }
        }

        gameObject.SetActive(false); //instead of doing this, later we can just change the model into a charred version of the same model.
    }
}
