using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverOK : MonoBehaviour
{
    // Start is called before the first frame update
    void Enter()
    {
        // private driver = DriverOK;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (VehicleOK car in FindObjectsOfType<VehicleOK>())
            {
                float distance = Vector3.Distance(this.transform.position, car.transform.position);
                if (distance < 3)
                {
                    Debug.Log("aaaaaaah too close");
                  //VehicleOK.Enter(DriverOK);
                    
                }

            }

        }
    }
}
