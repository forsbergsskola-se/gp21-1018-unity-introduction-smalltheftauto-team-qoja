using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingspotOK : MonoBehaviour
{


    public bool hasCar = false;
    

    public GameObject carPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
        if (hasCar)
        {
            Instantiate(carPrefab);
            carPrefab.transform.position = this.transform.position;
            hasCar = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
