using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            Vehicle[] foundVehicles = FindObjectsOfType<Vehicle>();
            
            foreach (Vehicle vehicle in foundVehicles)
            {
                for (int i = 0; i < foundVehicles.Length; i++) {
                    //DistanceCheck
                    //Temp(orary) closest object if current object is closer
                    //set current object to temp
                }
            }
        }
    }
}
