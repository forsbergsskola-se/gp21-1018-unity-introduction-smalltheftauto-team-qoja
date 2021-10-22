using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 100.0f;
    private Rigidbody2D rb;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() {
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody upwards constantly at speed you define (the green arrow axis in Scene view)
            rb.velocity = transform.up * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody downwards constantly at the speed you define (the green arrow axis in Scene view)
            rb.velocity = -transform.up * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //rotate the sprite about the Z axis in the positive direction
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rotate the sprite about the Z axis in the negative direction
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
        
        //transform.Translate(0f, speed * Time.deltaTime*Input.GetAxis("Vertical"), 0f);
        //transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime*Input.GetAxis("Horizontal"));
    }
}
