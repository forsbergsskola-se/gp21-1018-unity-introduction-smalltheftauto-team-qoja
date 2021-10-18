using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJO : MonoBehaviour {
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 100.0f;

    void Start()
    {
        
    }

    void Update() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0, translation, 0f);
        transform.Rotate(0, 0, -rotation);

    }
}

