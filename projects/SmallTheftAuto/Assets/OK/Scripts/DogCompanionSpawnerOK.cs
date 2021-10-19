using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCompanionSpawnerOK : MonoBehaviour
{

    public GameObject dogPrefab1;
    public GameObject dogPrefab2;

    private GameObject dogInstance1;
    private GameObject dogInstance2; 
    //This field allows us to attach the dog prefab
    // Start is called before the first frame update
    void OnEnable()
    {
        dogInstance1 = Instantiate(dogPrefab1);
        dogInstance2 = Instantiate(dogPrefab2);//Here i invoke the instantiate method, with the DogPrefab as an argument. This Method spawns the dog.
        Debug.Log("Woof!");
    }

    private void OnDisable() // can change to OnDestroy if you want them to get destroyed when character does.
    {
        Destroy(dogInstance1);
        Destroy(dogInstance2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
