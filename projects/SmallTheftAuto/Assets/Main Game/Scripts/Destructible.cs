using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int fireThreshold = 30;
    public void InflictDamage(int damage) {
        health -= damage;
    }

    public void OnFire() {
        
    }
}
