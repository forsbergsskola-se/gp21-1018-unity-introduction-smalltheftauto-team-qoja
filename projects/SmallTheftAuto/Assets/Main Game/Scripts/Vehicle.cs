using System;
using UnityEngine;

public class Vehicle : MonoBehaviour //, IIsExploadable
{
    [SerializeField] private int Health = 100;
    private GameObject driver;
    [SerializeField] private int HealthThreshhold = 30;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    void Start() {
        GetComponent<VehicleMovement>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Building")
        {
            //Function here to take vehicle dmg
        }
        
    }

    void OnFire()
    {
        if (Health < HealthThreshhold)
        {
            //Trigger car on fire animation
            //SetOnFire(); // We want a method here to set the car on fire
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
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
        gameObject.tag = "Player";
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        driver.SetActive(true);
        Debug.Log("I'm exited");
        //player = driver;
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
        gameObject.tag = "Vehicle";
    }
} 

