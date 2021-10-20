using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VehicleJO : MonoBehaviour {
    public GameObject player;
    
    private bool insideCar;

    private Vector3 playerOffset = new Vector3(3, 0, 0);


    // Start is called before the first frame update
    void Start() {
        GetComponent<CarMovementJO>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance( player.transform.position, transform.position);
        if (Input.GetButton("Interact-Vehicle") && distance < 3 && !insideCar) {
            //Split in isplayercclosetocar method
            //Put field bool inside car to method bool
            
            EnterCar();
        }

        //Get out
        if (Input.GetKeyDown(KeyCode.Q) && insideCar) {
            ExitCar(playerOffset);
        }
    }

    public void EnterCar() {
        player.SetActive(false);
        GetComponent<CarMovementJO>().enabled = true;
        insideCar = true;
    }

    public void ExitCar(Vector3 playerOffset) {
        player.transform.position = transform.position + playerOffset;
        player.SetActive(true);
        GetComponent<CarMovementJO>().enabled = false;
        insideCar = false;
    }
}