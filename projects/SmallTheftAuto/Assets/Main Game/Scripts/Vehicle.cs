using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour //, IIsExploadable
{
    [SerializeField] private int Health = 100;
    [SerializeField] private int healthThreshhold = 30;
    private GameObject driver;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    private int wallDamage = 10;
    private GameObject carExplosion;
    private int maxHealth = 100;
    private Explosion explosion;

    private void Awake()
    {
        GetComponent<VehicleMovement>().enabled = false; //diasble
        carExplosion = GameObject.Find("CarExplosion");
        explosion = GetComponent<Explosion>();
        explosion.enabled = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //Function here to take vehicle dmg
            TakeDamage(wallDamage);
            Debug.Log("Health of the car is: "+Health);
        }
        
    }
    

    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                ExitCar(playerOffset);
            }
        }
        if (Health == 0) OnDeath();
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
    }

    public void ExitCar(Vector3 playerOffset) {
        Debug.Log("I'm in exit method");
        driver.transform.parent = null;
        driver.transform.position = transform.position + playerOffset;
        driver.SetActive(true);
        Debug.Log("I exited");
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
    }

    //Destructible
    private void TakeDamage(int value)
    {
        Health -= value;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    private void OnDeath() {
        explosion.enabled = true;
        explosion.Explode();
        gameObject.SetActive(false);
    }
} 

