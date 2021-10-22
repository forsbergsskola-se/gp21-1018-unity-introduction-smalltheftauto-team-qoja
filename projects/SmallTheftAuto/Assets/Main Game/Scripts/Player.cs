using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int Health = 100;

    private int Money
    {
        get;
        set;
    }
    private int Score
    {
        get;
        set;
    }
    public bool IsAlive => Health > 0;
    public bool IsDead => !IsAlive;

    public void TakeDamage(int value)
    {
        Health -= value;
        if(IsDead)
        {
            OnDeath();
        }
    }

    // private Weapon Weapon    // We will need this later to apply weapons. But we need to create a weapon class and weapons first.
    // {
    //     get;
    //     set;
    // }

    public void EquipWeapon()
    {
        
    }

    public Player(int MaxHealth) //Player's constructior
    {
        this.Health = MaxHealth;

    }

    private void FixedUpdate()
    {
        
    }

    private void OnDeath()
    {
        
        //Do stuff first
        
        //RestartScene()  - Call this method from GameManager
    }
    
    // Access FindObjectOfType
    
    
}
