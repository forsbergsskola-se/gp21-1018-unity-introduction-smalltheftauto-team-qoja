using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    public GameObject player;
    private Vector3 playerOffset = new Vector3(3, 0, 0);

    private bool _isInsideCar;

    void Awake() {
    }

    void Update() {
        if (Input.GetButtonDown("Interact-Vehicle")) {
            if (!_isInsideCar) {
                EnterClosestVehicle();
                Debug.Log("I entered!");
                _isInsideCar = true;
            }
        }

        if (Input.GetButtonDown("Interact-Vehicle") && _isInsideCar) {
            Debug.Log("I try to exit!");
            GetComponent<Vehicle>().ExitCar(playerOffset, player);
            Debug.Log("I failed to exit!");
            _isInsideCar = false;
        }
    }

    public int FindClosestCar(float[] distancesToVehicles)
    {
        int indexOfClosestVehicle = 0;
        float closestPosition = 1000f;
        
        for(int i = 0; i < distancesToVehicles.Length; i++)
        {
            if (distancesToVehicles[i] < closestPosition)
            {
                closestPosition = distancesToVehicles[i];
                indexOfClosestVehicle = i;
            }
        }
        
        return indexOfClosestVehicle;
    }
    
    private void EnterClosestVehicle() {
        Vehicle[] foundVehicles = FindObjectsOfType<Vehicle>();
        float[] distancesToVehicles = new float[foundVehicles.Length];

        for (int i = 0; i < foundVehicles.Length; i++) {
            distancesToVehicles[i] = Vector2.Distance(this.transform.position, foundVehicles[i].transform.position);
        }

        int indexOfClosestCar = FindClosestCar(distancesToVehicles);

        if (distancesToVehicles[indexOfClosestCar] < 3) {
            foundVehicles[indexOfClosestCar].GetComponent<Vehicle>().EnterCar(player);
        }
    }
}
