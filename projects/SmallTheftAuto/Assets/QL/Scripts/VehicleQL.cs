using System;
using Unity.VisualScripting;
using UnityEngine;

public class VehicleQL : MonoBehaviour
{
    private GameObject driver;
    void Start()
    {
        GetComponent<CarMovementQL>().enabled = false;
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            if (driver != null)
            {
                LeaveCar();
            }
        }
        
    }

    public void EnterCar(GameObject player)
    {
        driver = player;
        player.SetActive(false);
        GetComponent<CarMovementQL>().enabled = true;
    }
    private void LeaveCar()
    {
        driver.transform.position = this.transform.position;
        driver.SetActive(true);
        //player = driver;
        driver = null;
        GetComponent<CarMovementQL>().enabled = false;
    }
}
