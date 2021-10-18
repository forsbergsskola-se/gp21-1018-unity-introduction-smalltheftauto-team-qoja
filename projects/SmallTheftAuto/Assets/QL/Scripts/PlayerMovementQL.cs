using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementQL : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 200.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Return -1 to 1 upon the input of "Vertical"(w,s,up,down) or "Horizonal"(a,d,left,down)
        float translation = Input.GetAxis("Vertical") * speed; 
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0f, translation, 0f);
        transform.Rotate(0f,0f,rotation);
    }
}
