using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] private float accelerationPower = 30000f;
    [SerializeField] private float steeringPower = 0.15f;
    [SerializeField] private float maxSpeed = 30000;
    private Rigidbody2D _rb;
    private float _steeringAmount, _speed, _direction;
    public float MAXSpeed
    {
        get => maxSpeed;
        set => maxSpeed = (value * 10);
    }
    
    private void Start ()
    {
        _rb = GetComponentInChildren<Rigidbody2D> ();
    }
    
    private void FixedUpdate ()
    {
        // Control for the steering wheel
        _steeringAmount =- Input.GetAxis("Horizontal");
        
        // Control for acceleration and break
        _speed = Mathf.Clamp((Input.GetAxis("Vertical") * accelerationPower), -MAXSpeed / 2, MAXSpeed);
        
        // Rotation
        _direction = Mathf.Sign(Vector2.Dot (_rb.velocity, _rb.GetRelativeVector(Vector2.up)));
        
        // Drifting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            steeringPower = 0.35f;
            accelerationPower = 15000f;
        }
        // Break
        else if (Input.GetKey(KeyCode.Space))
        {
            steeringPower = 0.35f;
            accelerationPower = 0f;
        }
        //Normal speed
        else
        {
            steeringPower = 0.15f;
            accelerationPower = 30000f;
        }
        
        _rb.rotation += _steeringAmount * steeringPower * _rb.velocity.magnitude * _direction;
        _rb.AddRelativeForce (Vector2.up * _speed);
        _rb.AddRelativeForce ( - Vector2.right * _rb.velocity.magnitude * _steeringAmount / 5);
    }
}
