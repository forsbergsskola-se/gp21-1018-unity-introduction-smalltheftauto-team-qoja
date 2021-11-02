using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    private bool parking;
    public bool parked;

    void Update()
    {
       IsCarParked();
    }

    private void IsCarParked()
    {
        Vehicle[] vehicles = FindObjectsOfType<Vehicle>();
        float[] distances = new float[vehicles.Length];
        for (int i = 0; i < vehicles.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, vehicles[i].transform.position);
        }

        int indexOfClosest = FindObject.FindIndexOfClosestObject(distances);
        if (distances[indexOfClosest] < 1 && !parking)
        {
            
            Debug.Log("parked");
            parked = true;
        }
        else parked = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        parking = true;
        Debug.Log("Trigger enter");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        parking = true;
        Debug.Log("Trigger stay");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        parking = false;
        Debug.Log("Trigger exit");
    }
}
