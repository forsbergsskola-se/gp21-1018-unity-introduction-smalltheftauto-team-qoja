using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DriverAA : MonoBehaviour
{
    public GameObject player;
    public PlayerMovementAA movement;
    private bool contactCar;
    private bool insideCar;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CarControllerAA[] car = FindObjectsOfType<CarControllerAA>();
        float distance =  Vector3.Distance(player.transform.position, car[0].transform.position);
        
        if (Input.GetKeyDown(KeyCode.E) && distance < 2)
        {

            EnterCar();

        }
        else
        {
            player.SetActive(true);
            movement.enabled = false;
            insideCar = false;
            
        }
    }
    void EnterCar()
    {
        player.SetActive(false);
        movement.enabled = true;
        insideCar = true;
    }
   
}
