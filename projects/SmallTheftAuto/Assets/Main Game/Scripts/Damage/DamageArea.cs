
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int damage;
    public float interval;
    
    private Destructible _destructible;
    private VehicleMovement _vehicleMovement;
    private Vehicle _vehicle;
    private IEnumerator _damageCoroutine;
    private bool _coroutineDamageStarted;
    private float _vehicleMaxSpeed;
    private bool _coroutineDisableCarStarted;
    private bool _stillInWater;
    private bool _waitingForSeconds;

    public enum DamageAreaType
    {
        Fire,
        Water
    }

    public bool InWater(DamageAreaType dArea)
    {
        switch (dArea)
        {
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
        _stillInWater = true;
        _destructible = other.gameObject.GetComponentInParent<Destructible>();
        _vehicleMovement = other.gameObject.GetComponentInParent<VehicleMovement>();
        if (_vehicleMovement != null)
        {
            _waitingForSeconds = true;
            Debug.Log("Starting WaitForSeconds");
            StartCoroutine(WaitForSecondsDisableCar(5, _vehicleMovement, _destructible));
        }
        _vehicle = other.gameObject.GetComponentInParent<Vehicle>();
        //vehicleMaxSpeed = _vehicleMovement.MAXSpeed;
        
        
        //KEEP
        if (_destructible != null)
        {
            _damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
            StartCoroutine(_damageCoroutine);
            _coroutineDamageStarted = true;
        }
        ///
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponentInParent<Vehicle>() == _vehicle)
        {
            _stillInWater = false;
        }
         //Problem might lay here
        
        _waitingForSeconds = false;
        
        //KEEP
        if (_coroutineDamageStarted)
        {
            StopCoroutine(_damageCoroutine);
        }
        ///
    }
    
    private IEnumerator WaitForSecondsDisableCar(int seconds, VehicleMovement vehicleMovement, Destructible destructible)
    {
        Debug.Log("In Disable car");
        _waitingForSeconds = true;
        yield return new WaitForSeconds(seconds);
        //waitingForSeconds = false;
        if (_stillInWater)
        {
            DisableCar(vehicleMovement, destructible);
        }
    }

    public void DisableCar(VehicleMovement vehicleMovement, Destructible destructible)
    {
        vehicleMovement.MAXSpeed = 0;
        destructible.enabled = false;
    }
    
}