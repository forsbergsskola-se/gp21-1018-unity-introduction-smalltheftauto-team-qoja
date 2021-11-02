using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItemsDestructible : Destructible
{
    public override void Update()
    {
        if (healthInterface.Health <= 0 && !hasDied) {
            OnDeath();
            return;
        }
    }

    public override void OnDeath()
    {
        //Destroy(this.gameObject.GetComponentInParent<GameObject>());
        Destroy(gameObject.transform.parent.gameObject);
        //this.gameObject.SetActive(false);
    }
    
}
