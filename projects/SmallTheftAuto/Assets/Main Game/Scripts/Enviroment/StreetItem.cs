using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItem : MonoBehaviour, IHurtOnCrash, IHaveHealth
{
    [SerializeField] private int maxHealth = 10;
    private int health;

    private void Awake() {
        health = maxHealth;
    }

    public int DamageOnCrash => 5;

    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, maxHealth);
    }
}
