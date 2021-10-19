using UnityEngine;

public class CarMovementQL : MonoBehaviour
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
    }
}
