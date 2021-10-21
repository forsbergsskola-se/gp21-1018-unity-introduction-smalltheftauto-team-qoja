using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    void Start() {
        GetComponent<VehicleMovement>().enabled = false;
    }

    public void EnterCar(GameObject player) {
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
    }

    public void ExitCar(Vector3 playerOffset, GameObject player) {
        player.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        player.SetActive(true);
        Debug.Log("I'm exited");

        GetComponent<VehicleMovement>().enabled = false;
    }
} 

