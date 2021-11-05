using System;
using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int damage;
    public float interval;
    public DamageAreaType dArea;
    private Destructible _destructible;
    private VehicleMovement _vehicleMovement;
    private Vehicle _vehicle;
    private IEnumerator _damageCoroutine;
    private float _vehicleMaxSpeed;
    private bool _coroutineDamageStarted;
    private bool _coroutineDisableCarStarted;
    private bool _stillInWater;

    public enum DamageAreaType
    {
        Fire,
        Water
    }

    private void Start() {
        dArea = DamageAreaType.Water;
    }

    public bool InWater()
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

    private void OnTriggerEnter2D(Collider2D other) {
        _destructible = other.gameObject.GetComponentInParent<Destructible>();
        
        if (_destructible != null)
        {
            _damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
            StartCoroutine(_damageCoroutine);
            _coroutineDamageStarted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_coroutineDamageStarted)
        {
            StopCoroutine(_damageCoroutine);
        }
    }
}