using UnityEngine;

public class Driver : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interact-Vehicle")) {
            EnterClosestVehicle();
        }
    }

    private void EnterClosestVehicle() {
        Vehicle[] foundVehicles = FindObjectsOfType<Vehicle>();
        float[] distancesToVehicles = new float[foundVehicles.Length];
        Vehicle closestCar;

        for (int i = 0; i < foundVehicles.Length; i++) {
            distancesToVehicles[i] = Vector2.Distance(this.transform.position, foundVehicles[i].transform.position);
        }
        
        int indexOfClosestCar = FindObject.FindIndexOfClosestObject(distancesToVehicles);

        if (distancesToVehicles[indexOfClosestCar] < 3) {
            closestCar = foundVehicles[indexOfClosestCar].GetComponent<Vehicle>();
            if (closestCar.enabled)
            {
                gameObject.transform.parent = closestCar.transform;
                closestCar.EnterCar(gameObject);
            }
            
        }
    }
}