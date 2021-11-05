using System;
using UnityEngine;

public class ShootingTarget : MonoBehaviour, IHaveHealth
{
    [SerializeField] public int maxHealth = 100;
    private int _health;
    

    private void Awake()
    {
        _health = maxHealth;
    }
    
    public int Health
    {
        get => _health;
        set => _health = Mathf.Clamp(value, 0, maxHealth);
    }

    public bool IsDead => Health == 0;

}
