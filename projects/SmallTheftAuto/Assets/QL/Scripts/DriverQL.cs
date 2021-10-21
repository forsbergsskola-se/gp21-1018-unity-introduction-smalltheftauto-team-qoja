using System;
using UnityEngine;

public class DriverQL : MonoBehaviour
{
    private GameObject driver;
    private void Start()
    {
        
    }

    void Update()
    {
        CarMovementQL[] car = FindObjectsOfType<CarMovementQL>();
        float distance = Vector3.Distance(this.transform.position, car[0].transform.position);
        if(Input.GetButtonDown("Interact-Vehicle"))
        {
            Debug.Log(distance);
            if (distance < 3)
            {
                //driver = FindObjectOfType<GameObject>();
                //driver.GetComponent<VehicleQL>().EnterCar();
                driver = GameObject.FindGameObjectWithTag("Player");
                GetComponent<VehicleQL>().EnterCar(driver);
            }
                

            // if (player.activeInHierarchy)
            // {
            //     float distance = Vector3.Distance(player.transform.position, movement.transform.position);
            //     if (distance < 3)
            //     {
            //         //player.GetComponent<VehicleQL>().EnterCar();
            //         try
            //         {
            //             player.GetComponent<VehicleQL>().EnterCar();
            //         }
            //         catch (NullReferenceException ex)
            //         {
            //             Debug.Log("player in the car");
            //         }
            //     }
            //         
            // }
            // else
            // {
            //     player.GetComponent<VehicleQL>().LeaveCar();
            // }
        }
    }
}
