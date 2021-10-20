using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarControllerJO : MonoBehaviour {
    public GameObject player;
    public GameObject car;
    public PlayerMovementJO movement;

    private bool insideCar;

    private Vector3 playerOffset = new Vector3(3, 0, 0);


    // Start is called before the first frame update
    void Start() {
        movement.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance( player.transform.position, car.transform.position);
        if (Input.GetButton("Interact-Vehicle") && distance < 3 && !insideCar) {
            EnterCar();
        }

        //Get out
        if (Input.GetKeyDown(KeyCode.Q) && insideCar) {
            ExitCar(playerOffset);
        }
    }

    private void EnterCar() {
        player.SetActive(false);
        movement.enabled = true;
        insideCar = true;
    }

    private void ExitCar(Vector3 playerOffset) {
        player.transform.position = car.transform.position + playerOffset;
        player.SetActive(true);
        movement.enabled = false;
        insideCar = false;
    }
}