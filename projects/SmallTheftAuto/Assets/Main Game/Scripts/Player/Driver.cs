using UnityEngine;

// TODO: Nice! :)
public class Driver : MonoBehaviour {
    private int _maxDistanceToEnter = 3;
    void Update()
    {
        if (Input.GetButtonDown("Interact-Vehicle"))
        {
            EnterClosestVehicle();
        }
    }
    
    private void EnterClosestVehicle()
    {
        Vehicle[] foundVehicles = FindObjectsOfType<Vehicle>();
        float[] distancesToVehicles = new float[foundVehicles.Length];

        //Creates an array of distances to all vehicles
        for (int i = 0; i < foundVehicles.Length; i++)
        {
            distancesToVehicles[i] = Vector2.Distance(transform.position, foundVehicles[i].transform.position);
        }
        
        int indexOfClosestCar = FindObject.FindIndexOfClosestObject(distancesToVehicles);

        //Enters the closest found vehicle if it's within the right distance
        if (distancesToVehicles[indexOfClosestCar] < _maxDistanceToEnter)
        {
            Vehicle closestCar = foundVehicles[indexOfClosestCar].GetComponent<Vehicle>();
            
            if (closestCar.enabled)
            {
                gameObject.transform.parent = closestCar.transform;
                closestCar.EnterCar(gameObject);
            }
        }
    }
}