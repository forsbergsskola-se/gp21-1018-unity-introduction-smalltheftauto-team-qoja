using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAA : MonoBehaviour
{
    // In order to change the speed in the Unity.
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Getting translation amd rotation values trough GetAxis method - and multiply by the speed defined
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        // Player movement 
        transform.Translate(0f,translation, 0f);
        transform.Rotate(0,0, -rotation);
        
    }
}
