using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class VehicleMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float accelerationPower = 30000f;
    [SerializeField] float steeringPower = 0.15f; //Has to be between 0-1
    [SerializeField] private float maxSpeed = 30000;
    float _steeringAmount, _speed, _direction;
    public float MAXSpeed
    {
        get => maxSpeed;
        set => maxSpeed = (value* 10);
    }

    // Initialization of RigidBody
    void Start () {
        _rb = GetComponentInChildren<Rigidbody2D> ();
    }
    
    void FixedUpdate () {

        // Control for the steering wheel
        _steeringAmount = - Input.GetAxis ("Horizontal");
        // Control for acceleration and break
        _speed = Mathf.Clamp((Input.GetAxis ("Vertical") * accelerationPower), -MAXSpeed/2, MAXSpeed);
        // Rotation
        _direction = Mathf.Sign(Vector2.Dot (_rb.velocity, _rb.GetRelativeVector(Vector2.up)));
        
        
        if (Input.GetKey(KeyCode.LeftShift)) // Drifting
        {
            steeringPower = 0.35f;
            accelerationPower = 15000f;
        }
        else if (Input.GetKey(KeyCode.Space)) // Break
        {
            steeringPower = 0.35f;
            accelerationPower = 0f;
        }
        else
        {
            steeringPower = 0.15f;
            accelerationPower = 30000f;
        }
        
        
        _rb.rotation += _steeringAmount * steeringPower * _rb.velocity.magnitude * _direction; 
        
        _rb.AddRelativeForce (Vector2.up * _speed); 

        _rb.AddRelativeForce ( - Vector2.right * _rb.velocity.magnitude * _steeringAmount / 5);
			
    }
}
