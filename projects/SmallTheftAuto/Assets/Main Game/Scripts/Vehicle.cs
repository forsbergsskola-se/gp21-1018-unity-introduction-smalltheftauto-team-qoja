using System;
using UnityEngine;

public class Vehicle : MonoBehaviour //, IIsExploadable
{
    [SerializeField] private int Health = 100;
    private GameObject driver;
    [SerializeField] private int healthThreshhold = 30;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    private int wallDamage = 10;
    private GameObject carExplosion;
    private int maxHealth = 100;
    void Start() {

    }

    private void Awake()
    {
        GetComponent<VehicleMovement>().enabled = false; //diasble
        carExplosion = GameObject.Find("CarExplosion");
        carExplosion.SetActive(false);
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

    void OnFire()
    {
        //Trigger car on fire animation
        //SetOnFire(); // We want a method here to set the car on fire
        Debug.Log("I'm on fire!");
        
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
        if(Health <= healthThreshhold) OnFire();
        if (Health == 0) OnDeath();
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.parent = null;
        driver.transform.position = transform.position + playerOffset;
        driver.SetActive(true);
        Debug.Log("I exited");
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
    }

    private void TakeDamage(int value)
    {
        Health -= value;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    private void OnDeath()
    {
        carExplosion.transform.position = gameObject.transform.position;
        carExplosion.SetActive(true);
        gameObject.SetActive(false);
    }
} 

