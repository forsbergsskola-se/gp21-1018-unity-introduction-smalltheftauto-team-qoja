using System;
using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Destructible _destructible;
    private VehicleMovement _vehicleMovement;
    public DamageAreaType areaType = new DamageAreaType();
    public int damage;
    public float interval;
    private IEnumerator damageCoroutine;
    private bool coroutineDamageStarted;
    private bool coroutineDisableCarStarted;
    
    public enum DamageAreaType {
        Fire,
        Water
    }

    bool InWater(DamageAreaType dArea) {
        switch (dArea) {
            case DamageAreaType.Fire:
                return false;
            case DamageAreaType.Water:
                return true;
            default:
                throw new ArgumentOutOfRangeException(nameof(dArea), dArea, null);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _destructible = other.gameObject.GetComponent<Destructible>();
        if (_destructible != null)
        {
            damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
            StartCoroutine(damageCoroutine);
            coroutineDamageStarted = true;
        }

        if (InWater(areaType)) {
            Debug.Log("Recognised water as true");
            _vehicleMovement = other.gameObject.GetComponentInParent<VehicleMovement>();
            if (_vehicleMovement != null) {
                StartCoroutine(DisableCar(_vehicleMovement));
                coroutineDisableCarStarted = true;
            } else {
                Debug.Log("Vehiclemov is null");
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (coroutineDamageStarted)
        {
            StopCoroutine(damageCoroutine);
        }

        if (coroutineDisableCarStarted) {
            StopCoroutine(DisableCar(_vehicleMovement));
        }
    }
    
    private IEnumerator DisableCar(VehicleMovement vehicleMovement) {
        Debug.Log("In Disable car");
             yield return new WaitForSeconds(5);
             vehicleMovement.enabled = false;
    }
}