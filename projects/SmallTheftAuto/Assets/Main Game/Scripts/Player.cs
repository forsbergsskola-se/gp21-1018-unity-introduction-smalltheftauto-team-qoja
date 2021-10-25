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

    private bool InFire = false;
    private int FireDamage = 5;
    private float timer;
    private int wait = 1;

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

    public Player(int MaxHealth) //Player's constructor
    {
        this.Health = MaxHealth;

    }
    
    

    private void Update()
    {
        
        // if (InFire)
        // {
        //     StartCoroutine("ImInFire");
        //     
        // }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            InFire = true;
            Debug.Log("I Enter fire");
            StartCoroutine("ImInFire");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            InFire = false;
            Debug.Log("I left fire");
        }
        
    }

    private IEnumerator ImInFire() //Takes x amount of damage every y seconds
    {
        TakeDamage(FireDamage);
        
        yield return new WaitForSeconds(1); 
        Debug.Log(InFire);
    }

    private void OnDeath()
    {
        
        //Do stuff first
        
        //RestartScene()  - Call this method from GameManager
    }
    
    // Access FindObjectOfType
    
    
}
