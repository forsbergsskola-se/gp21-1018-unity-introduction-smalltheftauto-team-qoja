using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool isParked;
    private bool _parkingCollision; // Used to check whether there is collision between the parking spot and the car
    
    void Update()
    {
       IsCarParked();
    }

    //Performance checked, this takes a long time to do. Maybe we can cache the array so we don't make a new one every update
    //Could also start this only after quest is started and then create the array
    
    // Check the distance between the parking spot and the car. The car is parked if the distance is smaller than 1 and no collision exists.
    private void IsCarParked()
    {
        Vehicle[] vehicles = FindObjectsOfType<Vehicle>();
        float[] distances = new float[vehicles.Length];
        for (int i = 0; i < vehicles.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, vehicles[i].transform.position);
        }

        int indexOfClosest = FindObject.FindIndexOfClosestObject(distances);
        if (distances[indexOfClosest] < 1 && !_parkingCollision)
        {
            isParked = true;
        }
        else isParked = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _parkingCollision = true;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        _parkingCollision = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _parkingCollision = false;
    }
}
