using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class DogCompanionSpawnerJO : MonoBehaviour {
    public GameObject dogPrefab;

    private GameObject dogInstance;
    // Start is called before the first frame update
    void Start() {
        dogInstance = Instantiate(dogPrefab);
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnDestroy() {
        Destroy(dogInstance);
    }
}
