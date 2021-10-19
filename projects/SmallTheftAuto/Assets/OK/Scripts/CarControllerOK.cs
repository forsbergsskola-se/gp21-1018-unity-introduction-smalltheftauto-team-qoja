using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerOK : MonoBehaviour
{

   // public GameObject CarPrefab;

   public GameObject player;
   
    public PlayerMovementOK movement;

    private bool touchingCar = false;
    // Start is called before the first frame update
    void Start()
    {
        movement.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        touchingCar = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingCar)
        {
            player.SetActive(false);
        }
    }
}
