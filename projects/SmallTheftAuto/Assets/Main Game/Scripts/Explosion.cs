using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5.0f;
    [SerializeField] private int explosionDamage = 50;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Material burnedMaterial;
    private Vector3 explosionAnimationOffset = new Vector3(0, 3, 0);

    protected void Start()
    {
        Explode();
    }

    public void Explode() {
        SpawnExplosion(explosionEffect, explosionAnimationOffset, Quaternion.identity);

        //Goes through the array and check if the gameobject of the collider has a burnable script component
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in nearbyColliders) {
            Destructible destructible = collider.gameObject.GetComponent<Destructible>();
            if (destructible != null) {
                Debug.Log($"I'm burnable {gameObject}");
                destructible.OnFire();
            } else {
                Debug.Log($"{gameObject} is not burnable");
            }

            Rigidbody2D rigidbody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody != null) {
                // Add a force to the rigidbody away from the explosion
            }
        }
        
        //gameObject.SetActive(false);
        
        if (burnedMaterial != null) {
            gameObject.GetComponent<MeshRenderer>().material = burnedMaterial;
        }
    }
    
    //I know this is copy paste code we might have to figure out how to put this in another script later so it can be used in all scripts
    //Currently throwing non-static error when calling from another script but "transform" can't be used in static method
    public GameObject SpawnExplosion(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;

    }
}
