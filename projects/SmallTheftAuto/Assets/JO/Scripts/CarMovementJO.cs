using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementJO : MonoBehaviour {
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 100.0f;

    void Start() {
        
    }

    void Update() {
        transform.Translate(0f, speed * Time.deltaTime*Input.GetAxis("Vertical"), 0f);
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime*Input.GetAxis("Horizontal"));
    }
}