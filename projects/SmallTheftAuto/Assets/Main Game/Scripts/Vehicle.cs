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
    void Start() {

    }

    private void Awake()
    {
        GetComponent<VehicleMovement>().enabled = false; //diasble
        carExplosion = GameObject.Find("CarExplosion");
        //carExplosion.SetActive(false);
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
        carExplosion.transform.position = gameObject.transform.position;
        carExplosion.SetActive(true);
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

    private void TakeDamage(int value)
    {
        Health -= value;
    }
} 

