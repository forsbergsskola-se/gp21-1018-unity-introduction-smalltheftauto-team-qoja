using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    //public GameObject player; // Should be automated
    
    private bool insideCar;

    private Vector3 playerOffset = new Vector3(3, 0, 0);


    // Start is called before the first frame update
    void Start() {
        GetComponent<VehicleMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance( player.transform.position, transform.position);
        if (Input.GetButton("Interact-Vehicle") && distance < 3 && !insideCar) {
            //Split in isplayercclosetocar method
            //Put field bool inside car to method bool
            
            EnterCar();
        }

        //Get out
        if (Input.GetKeyDown(KeyCode.Q) && insideCar) { //Change to interact vehicle
            ExitCar(playerOffset);
        }
    }

    public void EnterCar() {
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
        insideCar = true;
    }

    public void ExitCar(Vector3 playerOffset) {
        player.transform.position = transform.position + playerOffset;
        player.SetActive(true);
        GetComponent<VehicleMovement>().enabled = false;
        insideCar = false;
    }
} 

