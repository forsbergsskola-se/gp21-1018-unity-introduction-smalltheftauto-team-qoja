using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private int health = 100;
    private int money = 0;
    private int fireDamage = 5;
    
    public bool IsAlive => health > 0;
    public bool IsDead => !IsAlive;
    private bool inFire = false;

    public Player(int MaxHealth) //Player's constructor
    {
        this.health = MaxHealth;

    }
    
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
    
    // private Weapon Weapon    // We will need this later to apply weapons. But we need to create a weapon class and weapons first.
    // {
    //     get;
    //     set;
    // }
    
    private void Start() {
        Debug.Log("My health is " + health);
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

    private void TakeDamage(int damage)
    {
        Debug.Log("Damage value is " + damage);
        health -= damage;
        Debug.Log("My health is " + health);
        if(IsDead)
        {
            OnDeath();
        }
    }

    private IEnumerator ImInFire() //Takes x amount of damage every y seconds
    {
        while (inFire) {
            Debug.Log("Start : " + Time.time);
            Debug.Log("Firedamage is" + fireDamage);
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

    public void EquipWeapon()
    {
        
    }
}
