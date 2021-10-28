using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IHurtOnCrash
{
    public int DamageOnCrash => 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I am colliding");
        Destructible destructible = other.gameObject.GetComponentInParent<Destructible>();
        if (destructible != null)
        {
            destructible.TakeDamage(DamageOnCrash); 
        }
    }

    
}
