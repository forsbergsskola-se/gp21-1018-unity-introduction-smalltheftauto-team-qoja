using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    private bool parking;
    public bool parked;

    void Update()
    {
       IsCarParked();
    }

    //Perfomance checked, this takes a long time to do. Maybe we can cache the array so we don't make a new one every update
    //Could also start this only after quest is started and then create the array
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
            parked = true;
        }
        else parked = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        parking = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        parking = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        parking = false;
    }
}
