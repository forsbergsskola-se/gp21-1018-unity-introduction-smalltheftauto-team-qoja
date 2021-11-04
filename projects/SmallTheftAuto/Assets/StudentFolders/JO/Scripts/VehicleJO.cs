using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleJO : MonoBehaviour {
    private GameObject driver;
    private Vector3 playerOffset = new Vector3(3, 0, 0);
    
    void Start() {
        GetComponent<VehicleMovementJO>().enabled = false;
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
        GetComponent<VehicleMovementJO>().enabled = true;
        gameObject.tag = "Player";
    }

    public void ExitCar(Vector3 playerOffset) {
        driver.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        driver.SetActive(true);
        Debug.Log("I'm exited");
        //player = driver;
        driver = null;
        GetComponent<VehicleMovementJO>().enabled = false;
        gameObject.tag = "Vehicle";
    }
}