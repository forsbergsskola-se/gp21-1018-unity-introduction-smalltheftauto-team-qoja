using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementOK : MonoBehaviour
{
    //This allows for Easier customizing inside unity.
    [SerializeField] public float moveSpeed = 10;
    [SerializeField] public float rotationSpeed = 100;
    //public Rigidbody rig;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        //This checks your W/S input + our speed
        float translation = Input.GetAxis("Vertical") * moveSpeed;
        //This checks your A/D input + our rotational speed
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        //This makes sure it works the same on all computers regardless of lag.
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // rig.velocity = new Vector3(translation,0 , rig.velocity.z);
        //This changes the Y value of the player depending on your key input
        transform.Translate(0f, translation, 0f); 
        //this changes the zAngle value of the player depending on your key input
        transform.Rotate(0,0,-rotation);

    }
}