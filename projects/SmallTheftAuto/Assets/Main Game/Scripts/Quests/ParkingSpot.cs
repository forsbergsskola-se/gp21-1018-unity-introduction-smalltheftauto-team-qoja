using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool isParked;
    private bool _parkingCollision;
    
    private void Update()
    {
       IsCarParked();
    }

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
        
        if (distances[indexOfClosest] < 1 && !_parkingCollision) // TODO: Not sure, what `parkingCollision` does.
        // But I am sure, that the algorithm could be easier, if you just had a function that checks:
        // bool IsAnyCarParked(){
        // for(int i ....)
        // if(Vector2.Distance(...) < 1) return true;
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
