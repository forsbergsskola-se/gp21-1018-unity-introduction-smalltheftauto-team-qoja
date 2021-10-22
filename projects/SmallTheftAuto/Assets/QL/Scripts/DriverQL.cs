using System;
using UnityEngine;

public class DriverQL : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Interact-Vehicle"))
        {
            CarMovementQL[] cars = FindObjectsOfType<CarMovementQL>();
            float[] distances = new float[cars.Length];
            for (int i = 0; i < cars.Length; i++)
            {
                distances[i] = Vector3.Distance(this.transform.position, cars[i].transform.position);
            }
            int index = Min(distances);
            Debug.Log(distances[index]);
            if (distances[index] < 3)
            {
                cars[index].GetComponent<VehicleQL>().EnterCar(this.gameObject);
            }
            
            else Debug.Log("Cannot enter the car");
        }
    }

    private int Min(float[] array)
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
