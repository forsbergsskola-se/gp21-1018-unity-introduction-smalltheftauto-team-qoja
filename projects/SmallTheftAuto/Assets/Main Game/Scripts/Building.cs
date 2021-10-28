using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IHurtOnCrash, IHaveHealth {
    [SerializeField] private int maxHealth = 400;
    private int health;

    private void Awake() {
        health = maxHealth;
    }

    public int DamageOnCrash => 10;

    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(health, 0, maxHealth);
    }
}