using System;
using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Destructible _destructible;
    public DamageAreas typeOfArea = new DamageAreas();
    private IEnumerator damageCoroutine;
    private bool coroutineStarted;
    
    public enum DamageAreas
    {
        Fire,
        Water
    }

    int DamageOfArea(DamageAreas dArea)
    {
        switch (dArea)
        {
            case DamageAreas.Fire:
                return 5;
            case DamageAreas.Water:
                return 3;
            default:
                throw new ArgumentOutOfRangeException(nameof(dArea), dArea, null);
        }
    }

    int DamageInterval(DamageAreas dArea)
    {
        switch (dArea)
        {
            case DamageAreas.Fire:
                return 2;
            case DamageAreas.Water:
                return 3;
            default:
                throw new ArgumentOutOfRangeException(nameof(dArea), dArea, null);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _destructible = other.gameObject.GetComponent<Destructible>();
        if (_destructible != null)
        {
            damageCoroutine = _destructible.TakeDamageOverTime(DamageOfArea(typeOfArea), DamageInterval(typeOfArea));
            StartCoroutine(damageCoroutine);
            coroutineStarted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (coroutineStarted)
        {
            StopCoroutine(damageCoroutine);
        }
    }
}
