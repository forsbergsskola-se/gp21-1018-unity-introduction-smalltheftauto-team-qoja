using System;
using Unity.VisualScripting;
using UnityEngine;

public class Vehicle : MonoBehaviour, IHurtOnCrash
{
    
    
    private GameObject driver;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    private int buildingDamage = 10;
    
    private Explosion explosion;
    private Destructible destructibleScript;

    public int DamageOnCrash => 5;
    
    private void Awake()
    {
        destructibleScript = GetComponent<Destructible>();
        GetComponent<VehicleMovement>().enabled = false; //diasble
        explosion = GetComponent<Explosion>();
        explosion.enabled = false;
    }
    
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.GetComponent<Building>())
    //     {
    //         //Function here to take vehicle dmg
    //         //Debug.Log("Health of the car is: "+destructibleScript.health);
    //     }
    //     
    // }
    

    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                ExitCar(playerOffset);
            }
        }
       //if (Health == 0) OnDeath();
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

    private void OnDeath() {
        explosion.enabled = true;
        explosion.Explode();
        gameObject.SetActive(false);
    }

    
} 

