using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] float walkSpeed = 10.0f;

    void Update()
    {

        if (Input.GetAxis("Run-Button") != 0)
        {

            speed = runSpeed;
        }
        else speed = walkSpeed;
        
         transform.Translate(0f, speed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
