using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class VehicleMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    private float accelerationPower = 30000f;
    [SerializeField]
    float steeringPower = 0.15f; //Has to be between 0-1
    float steeringAmount, speed, direction;
    [SerializeField] private float maxSpeed = 30000;

    public float MAXSpeed
    {
        get => maxSpeed;
        set => maxSpeed = (value* 10);
    }

    // Use this for initialization
    void Start () {
        rb = GetComponentInChildren<Rigidbody2D> ();
    }
	
    // Update is called once per frame
    void FixedUpdate () {

        steeringAmount = - Input.GetAxis ("Horizontal");
       // speed = Input.GetAxis ("Vertical") * accelerationPower;
      
        speed = Mathf.Clamp((Input.GetAxis ("Vertical") * accelerationPower), -MAXSpeed/2, MAXSpeed);
        direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            steeringPower = 0.35f;
            accelerationPower = 15000f;
        }
        else
        {
            steeringPower = 0.15f;
            accelerationPower = 30000f;
        }
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction; 
        
        

        rb.AddRelativeForce (Vector2.up * speed); //Ask teacher how this works

        rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 5);
			
    }
}
