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
        Debug.Log("I am awake");
        Explode();
    }

    public void Explode() {
        //Stores colliders that are in explosion radius in an array
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        
        //Goes through the array and check if the gameobject of the collider has a burnable script component
        foreach (Collider2D collider in nearbyColliders) {
            IBurnable burnable = collider.gameObject.GetComponent<IBurnable>();
            burnable?.OnFire();

            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                // Add a force to the rigidbody away from the explosion
            }
        }

        gameObject.SetActive(false); //instead of doing this, later we can just change the model into a charred version of the same model.
    }
}
