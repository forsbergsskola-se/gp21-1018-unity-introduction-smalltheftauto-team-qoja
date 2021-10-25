using UnityEngine;

public class Driver : MonoBehaviour {
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
        Vehicle closestCar;

        for (int i = 0; i < foundVehicles.Length; i++) {
            distancesToVehicles[i] = Vector2.Distance(this.transform.position, foundVehicles[i].transform.position);
        }

        int indexOfClosestCar = FindClosestCar(distancesToVehicles);

        if (distancesToVehicles[indexOfClosestCar] < 3) {
            closestCar = foundVehicles[indexOfClosestCar].GetComponent<Vehicle>();
            gameObject.transform.parent = closestCar.transform;
            closestCar.EnterCar(gameObject);
        }
    }
}
