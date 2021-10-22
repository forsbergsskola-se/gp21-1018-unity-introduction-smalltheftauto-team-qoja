using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarControllerAA : MonoBehaviour
{
    public GameObject player;
    public PlayerMovementAA movement;
    public GameObject car;
    private bool contactCar;
    private bool insideCar;
    private Vector3 playerOffset = new Vector3(1, 0, 0);
    public GameObject carText;
     
    
    
    // Start is called before the first frame update
    void Start()
    {
        movement.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        contactCar = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(player.transform.position, car.transform.position);
        
        
        if (Input.GetKeyDown(KeyCode.E) && contactCar)
        {
            EnterCar();
        }
        

        if (Input.GetKeyDown(KeyCode.Q) && insideCar)
        {
            LeaveCar();
        }
    }

    void EnterCar()
    {
        player.SetActive(false);
        movement.enabled = true;
        insideCar = true;
        carText.SetActive(true);
    }

    void LeaveCar()
    {
        player.transform.position = car.transform.position + playerOffset;
        player.SetActive(true);
        movement.enabled = false;
        insideCar = false;
    }
}
