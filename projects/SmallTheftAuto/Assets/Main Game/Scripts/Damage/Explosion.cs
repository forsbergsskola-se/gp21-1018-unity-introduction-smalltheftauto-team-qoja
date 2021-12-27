using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5.0f;
    [SerializeField] private int explosionDamage = 50;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Material burnedMaterial;
    private readonly Vector3 _explosionAnimationOffset = new Vector3(0, 3, 0);

    // TODO: This looks great! :)
    public void Explode()
    {
        SpawnExplosion(explosionEffect, _explosionAnimationOffset, Quaternion.identity);
        
        //Looks for nearby colliders within the radius of the explosion
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D colliderFound in nearbyColliders)
        {
            Destructible destructible = colliderFound.gameObject.GetComponentInParent<Destructible>();
            
            if (destructible != null)
            {
                destructible.TakeDamage(explosionDamage);
                destructible.OnFire();
            }
        }
        
        if (burnedMaterial != null)
        {
            gameObject.GetComponent<MeshRenderer>().material = burnedMaterial;
        }
    }
    
    public void SpawnExplosion(GameObject prefab, Vector3 relativePosition, Quaternion relativeRotation)
    {
        GameObject childObj = Instantiate(prefab, transform, true);
        childObj.transform.localPosition = relativePosition;
        childObj.transform.localRotation = relativeRotation;
        childObj.transform.localScale = Vector3.one;
    }

    //Disables all monobehaviour scripts on exploded object
    public void DisableAfterExplosion()
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }
}