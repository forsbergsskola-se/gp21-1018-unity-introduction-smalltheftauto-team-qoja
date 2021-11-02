using System;
using System.Collections;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    private Destructible _destructible;
    public int damage;
    public float interval;
    private IEnumerator damageCoroutine;
    private bool coroutineStarted;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _destructible = other.gameObject.GetComponent<Destructible>();
        if (_destructible != null)
        {
            damageCoroutine = _destructible.TakeDamageOverTime(damage, interval);
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