using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnterAA : MonoBehaviour
{
    public GameObject player;
    public PlayerMovementAA movement;
    private bool contactCar = false;
    
    // Start is called before the first frame update
    void Start()
    {
        movement.enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        contactCar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && contactCar)
        {
            player.SetActive(false);
        }
    }
}
