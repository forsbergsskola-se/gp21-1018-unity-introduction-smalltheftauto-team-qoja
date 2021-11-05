using System;
using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public DamageAreaType dArea;
    public int damage;
    public float interval;
    private Destructible _destructible;
    private IEnumerator _damageCoroutine;
    private bool _coroutineDamageStarted;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
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