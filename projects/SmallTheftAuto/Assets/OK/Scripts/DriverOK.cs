using UnityEngine;

public class DriverOK : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interact-VehicleOK")) {
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
        VehicleOK[] foundVehicles = FindObjectsOfType<VehicleOK>();
        float[] distancesToVehicles = new float[foundVehicles.Length];

        for (int i = 0; i < foundVehicles.Length; i++) {
            distancesToVehicles[i] = Vector2.Distance(this.transform.position, foundVehicles[i].transform.position);
        }

        int indexOfClosestCar = FindClosestCar(distancesToVehicles);

        if (distancesToVehicles[indexOfClosestCar] < 3) {
            foundVehicles[indexOfClosestCar].GetComponent<VehicleOK>().EnterCar(this.gameObject);
        }
    }
}