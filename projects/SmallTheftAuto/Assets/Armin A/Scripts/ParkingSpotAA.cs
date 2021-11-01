using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpotAA : MonoBehaviour
{
    public bool hasCar;
    public GameObject carPrefab;
    void Start()
    {
        if (hasCar)
        {
            GameObject instance = Instantiate(carPrefab);
            //Instantiate(instance, transform.position, Quaternion.Euler(0, 0, 0));
            instance.transform.position = gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
