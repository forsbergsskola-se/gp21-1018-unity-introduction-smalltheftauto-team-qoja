using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField] private float explosionRadius = 5.0f;
    [SerializeField] private int explosionDamage = 50;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Material burnedMaterial;
    private Vector3 explosionAnimationOffset = new Vector3(0, 3, 0);

    protected void Start() {
        Explode();
    }

    public void Explode() {
        SpawnExplosion(explosionEffect, explosionAnimationOffset, Quaternion.identity);
        
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D colliderFound in nearbyColliders) {
            Destructible destructible = colliderFound.gameObject.GetComponentInParent<Destructible>();
            
            if (destructible != null) {
                destructible.OnFire();
            }
        }
        
        if (burnedMaterial != null) {
            gameObject.GetComponent<MeshRenderer>().material = burnedMaterial;
        }
        
        DisableAfterExplosion();
    }

    //I know this is copy paste code we might have to figure out how to put this in another script later so it can be used in all scripts
    //Currently throwing non-static error when calling from another script but "transform" can't be used in static method
    public GameObject SpawnExplosion(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation) {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
        return childObj;
    }

    public void DisableAfterExplosion() {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }
}