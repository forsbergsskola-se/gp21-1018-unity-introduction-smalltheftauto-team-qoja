using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSpot : MonoBehaviour
{
    public bool hasCar;
    public GameObject carPrefab;
    private float time;
    void Start()
    {
        time = 0;
        if (hasCar)
        {
            Vector3 carPosition = this.transform.position + new Vector3(0, 0.4f, 0);
            Instantiate(carPrefab, carPosition, Quaternion.identity);
            //Debug.Log("Position is: "+transform.position.x+transform.position.y+transform.position.z);
            
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time >= 10 && !hasCar)
        {
            Instantiate(carPrefab);
            carPrefab.transform.position = this.transform.position + new Vector3(0, 0.4f, 0);
            hasCar = true;
        }
    }
}
