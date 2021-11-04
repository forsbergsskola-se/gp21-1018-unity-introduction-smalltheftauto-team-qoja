
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Destructible _destructible;
    private VehicleMovement _vehicleMovement;
    private Vehicle _vehicle;
    public DamageAreaType areaType = new DamageAreaType();
    public int damage;
    public float interval;
    private IEnumerator damageCoroutine;
    private bool coroutineDamageStarted;
    private bool coroutineDisableCarStarted;
    private float vehicleMaxSpeed;
    private bool stillInWater;
    private bool waitingForSeconds;

    public enum DamageAreaType
    {
        Fire,
        Water
    }

    bool InWater(DamageAreaType dArea)
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
        stillInWater = true;
        _destructible = other.gameObject.GetComponentInParent<Destructible>();
        _vehicleMovement = other.gameObject.GetComponentInParent<VehicleMovement>();
        if (_vehicleMovement != null)
        {
            waitingForSeconds = true;
            Debug.Log("Starting WaitForSeconds");
            StartCoroutine(WaitForSecondsDisableCar(5, _vehicleMovement, _destructible));
        }
        _vehicle = other.gameObject.GetComponentInParent<Vehicle>();
        //vehicleMaxSpeed = _vehicleMovement.MAXSpeed;
        if (_destructible != null)
        {
            damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
            StartCoroutine(damageCoroutine);
            coroutineDamageStarted = true;
        }
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (InWater(areaType))
    //     {
    //         if (_vehicle != null)
    //         {
    //             if (waitingForSeconds == false)
    //             {
    //                 waitingForSeconds = true;
    //                 Debug.Log("Starting WaitForSeconds");
    //                 StartCoroutine(WaitForSecondsDisableCar(5, _vehicleMovement, _destructible));
    //                 
    //             }
    //         }
    //         else
    //         {
    //             Debug.Log("Vehiclemov is null");
    //         }
    //     }
    //
    // }

    private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponentInParent<Vehicle>() == _vehicle)
            {
                stillInWater = false;
            }
             //Problem might lay here
            
            waitingForSeconds = false;
            if (coroutineDamageStarted)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    
        private IEnumerator WaitForSecondsDisableCar(int seconds, VehicleMovement vehicleMovement, Destructible destructible)
        {
            Debug.Log("In Disable car");
            waitingForSeconds = true;
            yield return new WaitForSeconds(seconds);
            //waitingForSeconds = false;
            if (stillInWater)
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