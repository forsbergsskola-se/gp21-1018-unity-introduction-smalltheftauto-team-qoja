using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour {
    private GameObject player = GameObject.FindGameObjectWithTag("Player");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Interact-Vehicle")) {
            //if insidecar
            //no then you can enter
            //if yes, you can get out
            Vehicle[] foundVehicles = FindObjectsOfType<Vehicle>();
            float[] distancesToVehicles = new float[foundVehicles.Length];
            
            for (int i = 0; i < foundVehicles.Length; i++) {
                distancesToVehicles[i] = Vector2.Distance(this.transform.position, foundVehicles[i].transform.position);
            }
            
            int indexOfClosestCar = FindClosestCar(distancesToVehicles);
            
            if (distancesToVehicles[indexOfClosestCar] < 3)
            {
                foundVehicles[indexOfClosestCar].GetComponent<Vehicle>().EnterCar(player);
            }

            
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
    
    public int Min(float[] array)
    {
        int index=0;
        float tmp = 1000f;
        for(int i=0; i<array.Length; i++)
        {
            if (array[i] < tmp)
            {
                tmp = array[i];
                index = i;
            }
        }
        return index;
    }
}
