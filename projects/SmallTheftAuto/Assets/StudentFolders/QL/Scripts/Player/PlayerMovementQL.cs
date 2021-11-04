using UnityEngine;

public class PlayerMovementQL : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float rotationSpeed = 180.0f;
    
    void Start()
    {
       
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed; 
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0f, translation, 0f);
        transform.Rotate(0f,0f,rotation);

        
        // if (Input.GetKey(KeyCode.W)) transform.Translate(0f, 0.01f, 0f);
        // if (Input.GetKey(KeyCode.S)) transform.Translate(0f, -0.01f, 0f);
        // if(Input.GetKey(KeyCode.A)) transform.Rotate(0f, 0f, 1.0f);
        // if(Input.GetKey(KeyCode.D)) transform.Rotate(0f, 0f, -1.0f);
    }
}
