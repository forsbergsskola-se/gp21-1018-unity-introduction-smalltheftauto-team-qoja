using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public GameObject player;
    public GameObject car;
    public PlayerMovementJO movement;

    private bool touchingCar;
    // Start is called before the first frame update
    void Start() {
        movement.enabled = false;
    }

    private void OnCollisionEnter(Collision other) {
        touchingCar = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingCar) {
            player.SetActive(false);
            movement.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            player.SetActive(true);
            movement.enabled = false;
        }
    }
}
