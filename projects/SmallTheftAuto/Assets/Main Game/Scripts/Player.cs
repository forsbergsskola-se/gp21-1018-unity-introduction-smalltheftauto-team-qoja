using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int health = 100;
    private int money = 0;

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
    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;

    private bool inFire = false;
    private int fireDamage = 5;

    public void TakeDamage(int value)
    {
        health -= value;
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
        this.health = MaxHealth;

    }
    
    

    private void Update()
    {
        
        if (inFire)
        {

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            inFire = true;
            Debug.Log("I am in fire");
            StartCoroutine(ImInFire());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            inFire = false;
            Debug.Log("I left fire");
        }
        
    }

    private IEnumerator ImInFire() //Takes x amount of damage every y seconds
    {
        while (inFire) {
            Debug.Log("Start : " + Time.time);
            TakeDamage(fireDamage);
            Debug.Log(health);
            yield return new WaitForSeconds(3);
            Debug.Log("Finished damage: " + Time.time);
        }
    }

    private void OnDeath()
    {
        
        //Do stuff first
        
        //RestartScene()  - Call this method from GameManager
    }
    
    // Access FindObjectOfType
    
    
}
