using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleOK : MonoBehaviour
{
    void Start() {
        GetComponent<VehicleMovement>().enabled = false;
    }

    public void EnterCar(GameObject player) {
        player.SetActive(false);
        GetComponent<VehicleMovement>().enabled = true;
        gameObject.tag = "Player";
    }

    public void ExitCar(Vector3 playerOffset, GameObject player) {
        player.transform.position = transform.position + playerOffset;
        Debug.Log("I'm suppose to exit");
        player.SetActive(true);
        Debug.Log("I'm exited");
        gameObject.tag = "Vehicle";
        GetComponent<VehicleMovement>().enabled = false;
        
    }
}