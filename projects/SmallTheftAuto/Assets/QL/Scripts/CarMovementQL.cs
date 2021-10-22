using UnityEngine;

public class CarMovementQL : MonoBehaviour
{
    [SerializeField] float accelerationGear = 1.0f;
    [SerializeField] float steeringGear = 1.0f;
    private float steering, acceleration;
    
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        acceleration = Input.GetAxis("Vertical") * accelerationGear * 10;
        steering = -Input.GetAxis("Horizontal") * steeringGear / 2 ;
        float direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        //direction is 1 if car is moving forward and -1 if reverse
        rb.rotation += steering * rb.velocity.magnitude * direction;
        rb.AddRelativeForce(Vector2.up * acceleration * rb.mass);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steering * rb.mass);
    }
}
