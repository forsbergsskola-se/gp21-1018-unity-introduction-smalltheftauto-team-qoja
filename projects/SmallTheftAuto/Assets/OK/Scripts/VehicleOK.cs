using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleOK : MonoBehaviour
{

    // public GameObject CarPrefab;

    public GameObject player;

    //public CarMovementOK movement;
    public GameObject car;

    private bool touchingCar = false;

    //private bool insideCar = false;
    private Vector3 playerOffSet = new Vector3(2,0,0);

    
    


    public Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CarMovementOK>().enabled = false; //To automatically assign the Carmovement script
        //player = FindObjectOfType<PlayerMovementOK>();
        //PlayerOK playerOk = FindObjectOfType<PlayerOK>();
        this.player = player;

    }
bool PlayerIsInCar()
    {
        return !this.player.activeInHierarchy;
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     touchingCar = true;
    // }

    // Update is called once per frame
    void Update()
    {
        //FindObjectsOfType<PlayerMovementOK>

        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if(Input.GetKeyDown(KeyCode.E))
        {
            
               if ( this.player.activeInHierarchy && distance < 3)
               {
                   EnterCar();
               }
               else
               {
                   ExitCar();
               }
        }
        

        void EnterCar()
        {
            player.SetActive(false);
            GetComponent<CarMovementOK>().enabled = true;
            //insideCar = true;
           // PlayerIsInCar();

        }

        void ExitCar()
        {
            
            player.SetActive(true);
            player.transform.position = car.transform.position + playerOffSet;
            GetComponent<CarMovementOK>().enabled = false;
           // insideCar = false;
           
        }
          
    }
}
