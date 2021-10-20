using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerOK : MonoBehaviour
{

    // public GameObject CarPrefab;

    public GameObject player;

    public CarMovementOK movement;
    public GameObject car;

    private bool touchingCar = false;

    private bool insideCar = false;
    private Vector3 playerOffSet = new Vector3(2,0,0);
    
    


    public Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        movement.enabled = false;

    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     touchingCar = true;
    // }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(player.transform.position, car.transform.position);

        if (distance < 3)
        {
           if (Input.GetKeyUp(KeyCode.E) && insideCar == false)
           {
               EnterCar();
            } 
        }

        
        else if (Input.GetKeyUp(KeyCode.E) && insideCar)
        {
            ExitCar();
        }

        void EnterCar()
        {
            player.SetActive(false);
            movement.enabled = true;
            insideCar = true;
            
        }

        void ExitCar()
        {
            
            player.SetActive(true);
            player.transform.position = car.transform.position + playerOffSet;
            movement.enabled = false;
            insideCar = false;
        }
          
    }
}
