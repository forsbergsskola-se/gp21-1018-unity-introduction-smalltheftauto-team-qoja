using System;
using System.Collections;
using Unity.VisualScripting;
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
    private float vehicleMaxSpeed;
    
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
       // _destructible = other.gameObject.GetComponent<Destructible>();
        _destructible = other.gameObject.GetComponentInParent<Destructible>();
        _vehicleMovement = other.gameObject.GetComponentInParent<VehicleMovement>();
        //vehicleMaxSpeed = _vehicleMovement.MAXSpeed;
        if (_destructible != null)
        {
            damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
            StartCoroutine(damageCoroutine);
            coroutineDamageStarted = true;
        }

        if (InWater(areaType)) {
            Debug.Log("Recognised water as true");
             
             //_destructible = other.gameObject.GetComponentInParent<Destructible>();
            // _vehicle = other.gameObject.GetComponentInParent<Vehicle>();
            if (_vehicleMovement != null) {
                coroutineDisableCarStarted = true;
                StartCoroutine(DisableCar(_vehicleMovement));
                
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
            _vehicleMovement.MAXSpeed = vehicleMaxSpeed;
        }
    }
    
    private IEnumerator DisableCar(VehicleMovement vehicleMovement) {
        Debug.Log("In Disable car");
             yield return new WaitForSeconds(5);
             vehicleMovement.MAXSpeed = 0;
             _destructible.enabled = false;
             // _vehicle.enabled = false;

    }
}