using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, IBurnable, IDamageable
{
    [SerializeField] private int health = 100;
    [SerializeField] private int fireThreshold = 30;

    public void OnFire() {
        Debug.Log(gameObject + "on fire");
        //Trigger fire animation
        //Fire dies after a certain time
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }
}
