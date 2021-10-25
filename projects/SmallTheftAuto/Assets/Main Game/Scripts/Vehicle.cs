using System;
using UnityEngine;

public class Vehicle : MonoBehaviour //, IIsExploadable
{
    [SerializeField] private int Health = 100;
    private GameObject driver;
    [SerializeField] private int healthThreshhold = 30;
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
        if (Health < healthThreshhold)
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
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.parent = null;
        driver.transform.position = transform.position + playerOffset;
        driver.SetActive(true);
        Debug.Log("I exited");
        driver = null;
        GetComponent<VehicleMovement>().enabled = false;
    }
} 

