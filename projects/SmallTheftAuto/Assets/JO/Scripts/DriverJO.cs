using UnityEngine;

public class DriverJO : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interact-Vehicle")) {
            EnterClosestVehicle();
            Debug.Log("I entered!");
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
            foundVehicles[indexOfClosestCar].GetComponent<Vehicle>().EnterCar(this.gameObject);
        }
    }
}